using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FloydSteinbergGUI
{
    public class FSDitherLib
    {
        public static async Task <Bitmap >TransDither(Bitmap inputImage, int type, int bit, int level, double brightness)
        {
            Bitmap retVal = new Bitmap(inputImage.Width, inputImage.Height);
            await Task.Run(() => {
                if (type == 0)
                {
                    //BW
                    if (bit == 0)
                    {
                        retVal = FloydSteinbergDitheringBW8Bit(inputImage, brightness, level);
                        //retVal = squareBlur(inputImage);
                    }
                    else
                    {
                        retVal = FloydSteinbergDitheringBW(inputImage, brightness, level);
                    }
                }
                else
                {
                    //Color
                    if (bit == 0)
                    {
                        retVal = FloydSteinbergDitheringColor8bit(inputImage, brightness,level);
                    }
                    else
                    {
                        retVal = FloydSteinbergDitheringColor(inputImage, brightness,level);
                    }
                }
            });

            return retVal;
        }
        //Library
        static Bitmap FloydSteinbergDitheringBW8Bit(Bitmap inputImage,double light, double  level)
        {
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    Color oldPixel = inputImage.GetPixel(x, y);
                    int newRed = grayscaleLevelCheck(oldPixel.R * light, 8, level); // 将红色值转换为黑白
                    int newGreen = grayscaleLevelCheck(oldPixel.G * light, 8, level); // 将绿色值转换为黑白
                    int newBlue = grayscaleLevelCheck(oldPixel.B * light, 8, level); // 将蓝色值转换为黑白
                    double luma = Convert.ToDouble(newRed)*0.2126 + Convert.ToDouble(newGreen)*0.7152 + Convert.ToDouble(newBlue)*0.0722;
                    int newPixel = (int)Math.Round(luma);
                    outputImage.SetPixel(x, y, Color.FromArgb(newPixel, newPixel, newPixel));

                    int quantError = oldPixel.R - newPixel;

                    if (x + 1 < inputImage.Width)
                        PropagateError(inputImage, x + 1, y, quantError, 7.0 / 16.0);
                    if (x - 1 >= 0 && y + 1 < inputImage.Height)
                        PropagateError(inputImage, x - 1, y + 1, quantError, 3.0 / 16.0);
                    if (y + 1 < inputImage.Height)
                        PropagateError(inputImage, x, y + 1, quantError, 5.0 / 16.0);
                    if (x + 1 < inputImage.Width && y + 1 < inputImage.Height)
                        PropagateError(inputImage, x + 1, y + 1, quantError, 1.0 / 16.0);
                }
            }

            return outputImage;
        }
        static Bitmap FloydSteinbergDitheringBW(Bitmap inputImage, double light, double level)
        {
            //Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            bit10Bitmap input10Image = new bit10Bitmap();
            input10Image.bit8Transbit10(inputImage);
            bit10Bitmap output10Image = new bit10Bitmap(inputImage.Width, inputImage.Height);

            for (int y = 0; y < input10Image.Height; y++)
            {
                for (int x = 0; x < input10Image.Width; x++)
                {
                    bit10Bitmap.unitBitData oldPixel = input10Image.GetPixel(x, y);
                    ushort newRed = grayscaleLevelCheck(oldPixel.R * light, 10, level); // 将红色值转换为黑白
                    ushort newGreen = grayscaleLevelCheck(oldPixel.G * light, 10, level);// 将绿色值转换为黑白
                    ushort newBlue = grayscaleLevelCheck(oldPixel.B * light, 10, level); // 将蓝色值转换为黑白
                    double luma = Convert.ToDouble(newRed) * 0.2126 + Convert.ToDouble(newGreen) * 0.7152 + Convert.ToDouble(newBlue) * 0.0722;
                    ushort newPixel = (ushort)Math.Round(luma);
                    output10Image.SetPixel(x, y, oldPixel.A, newPixel, newPixel, newPixel);

                    int quantError = oldPixel.R - newPixel;

                    if (x + 1 < input10Image.Width)
                        PropagateError(input10Image, x + 1, y, quantError, 7.0 / 16.0);
                    if (x - 1 >= 0 && y + 1 < input10Image.Height)
                        PropagateError(input10Image, x - 1, y + 1, quantError, 3.0 / 16.0);
                    if (y + 1 < input10Image.Height)
                        PropagateError(input10Image, x, y + 1, quantError, 5.0 / 16.0);
                    if (x + 1 < input10Image.Width && y + 1 < input10Image.Height)
                        PropagateError(input10Image, x + 1, y + 1, quantError, 1.0 / 16.0);
                }
            }

            return output10Image.bit10TransBmp();
        }
        static Bitmap FloydSteinbergDitheringColor(Bitmap inputImage,double light,double level)
        {
            //Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            bit10Bitmap input10Image = new bit10Bitmap();
            input10Image.bit8Transbit10(inputImage);
            bit10Bitmap output10Image = new bit10Bitmap(inputImage.Width, inputImage.Height);

            for (int y = 0; y < input10Image.Height; y++)
            {
                for (int x = 0; x < input10Image.Width; x++)
                {
                    bit10Bitmap.unitBitData oldPixel = input10Image.GetPixel(x, y);
                    ushort newRed = grayscaleLevelCheck(oldPixel.R * light, 10,level); // 将红色值转换为黑白
                    ushort newGreen = grayscaleLevelCheck(oldPixel.G * light, 10, level);// 将绿色值转换为黑白
                    ushort newBlue = grayscaleLevelCheck(oldPixel.B * light, 10, level); // 将蓝色值转换为黑白
                    output10Image.SetPixel(x, y, oldPixel.A, newRed, newGreen, newBlue);

                    int quantErrorRed = Convert.ToInt32(Math.Round((oldPixel.R * light - newRed)));
                    int quantErrorGreen = Convert.ToInt32(Math.Round((oldPixel.G * light - newGreen)));
                    int quantErrorBlue = Convert.ToInt32(Math.Round((oldPixel.B * light - newBlue)));

                    if (x + 1 < input10Image.Width)
                        PropagateError(input10Image, x + 1, y, quantErrorRed, quantErrorGreen, quantErrorBlue, 7.0 / 16.0);
                    if (x - 1 >= 0 && y + 1 < input10Image.Height)
                        PropagateError(input10Image, x - 1, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 3.0 / 16.0);
                    if (y + 1 < input10Image.Height)
                        PropagateError(input10Image, x, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 5.0 / 16.0);
                    if (x + 1 < input10Image.Width && y + 1 < input10Image.Height)
                        PropagateError(input10Image, x + 1, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 1.0 / 16.0);
                }
            }

            return output10Image.bit10TransBmp();
        }
        static Bitmap FloydSteinbergDitheringColor8bit(Bitmap inputImage,double light,double level)
        {
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);

            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    Color oldPixel = inputImage.GetPixel(x, y);
                    // Console.WriteLine($"A = {oldPixel.A}, R = {oldPixel.R}, G = {oldPixel.G}, B = {oldPixel.B}");
                    int newRed = grayscaleLevelCheck(oldPixel.R * light, 8,level); // 将红色值转换为黑白
                    int newGreen = grayscaleLevelCheck(oldPixel.G * light, 8,level); // 将绿色值转换为黑白
                    int newBlue = grayscaleLevelCheck(oldPixel.B * light, 8,level); // 将蓝色值转换为黑白
                    outputImage.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));

                    int quantErrorRed = Convert.ToInt32(Math.Round((oldPixel.R * light - newRed)));
                    int quantErrorGreen = Convert.ToInt32(Math.Round((oldPixel.G * light - newGreen)));
                    int quantErrorBlue = Convert.ToInt32(Math.Round((oldPixel.B * light - newBlue)));

                    if (x + 1 < inputImage.Width)
                        PropagateError(inputImage, x + 1, y, quantErrorRed, quantErrorGreen, quantErrorBlue, 7.0 / 16.0);
                    if (x - 1 >= 0 && y + 1 < inputImage.Height)
                        PropagateError(inputImage, x - 1, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 3.0 / 16.0);
                    if (y + 1 < inputImage.Height)
                        PropagateError(inputImage, x, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 5.0 / 16.0);
                    if (x + 1 < inputImage.Width && y + 1 < inputImage.Height)
                        PropagateError(inputImage, x + 1, y + 1, quantErrorRed, quantErrorGreen, quantErrorBlue, 1.0 / 16.0);
                }
            }

            return outputImage;
        }
        //階層
        static ushort grayscaleLevelCheck(double originColor, ushort bitcount,double level)
        {
            //先搞四階
            ushort unitlevel = Convert.ToUInt16(Math.Round((Math.Pow(2, bitcount)) / level));
            double currentLevelFloat = originColor / unitlevel;
            ushort newColor = Convert.ToUInt16(unitlevel * Math.Round(currentLevelFloat) != 0 ? Convert.ToUInt16(unitlevel * Math.Round(currentLevelFloat)) - 1 : 0);
            return newColor;

        }
        static void PropagateError(Bitmap image, int x, int y, int quantError, double ratio)
        {
            Color pixel = image.GetPixel(x, y);
            int newRed = (int)(Math.Round(pixel.R + quantError * ratio));
            int newGreen = (int)Math.Round(pixel.G + quantError * ratio);
            int newBlue = (int)Math.Round(pixel.B + quantError * ratio);

            newRed = Math.Min(255, Math.Max(0, newRed));
            newGreen = Math.Min(255, Math.Max(0, newGreen));
            newBlue = Math.Min(255, Math.Max(0, newBlue));

            image.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));
        }
        static void PropagateError(bit10Bitmap image, int x, int y, int quantError, double ratio)
        {
            bit10Bitmap.unitBitData pixel = image.GetPixel(x, y);
            int newRed = (int)Math.Round(pixel.R + quantError * ratio);
            int newGreen = (int)Math.Round(pixel.G + quantError * ratio);
            int newBlue = (int)Math.Round(pixel.B + quantError * ratio);

            newRed = Math.Min(1023, Math.Max(0, newRed));
            newGreen = Math.Min(1023, Math.Max(0, newGreen));
            newBlue = Math.Min(1023, Math.Max(0, newBlue));

            image.SetPixel(x, y, pixel.A, (ushort)newRed, (ushort)newGreen, (ushort)newBlue);
        }
        static void PropagateError(bit10Bitmap image, int x, int y, int quantErrorRed, int quantErrorGreen, int quantErrorBlue, double ratio)
        {
            bit10Bitmap.unitBitData pixel = image.GetPixel(x, y);
            //Color pixel = image.GetPixel(x, y);
            int newRed = (int)Math.Round(pixel.R + quantErrorRed * ratio);
            int newGreen = (int)Math.Round(pixel.G + quantErrorGreen * ratio);
            int newBlue = (int)Math.Round(pixel.B + quantErrorBlue * ratio);

            newRed = Math.Min(1023, Math.Max(0, newRed));
            newGreen = Math.Min(1023, Math.Max(0, newGreen));
            newBlue = Math.Min(1023, Math.Max(0, newBlue));

            image.SetPixel(x, y, pixel.A, (ushort)newRed, (ushort)newGreen, (ushort)newBlue);
        }
        static void PropagateError(Bitmap image, int x, int y, int quantErrorRed, int quantErrorGreen, int quantErrorBlue, double ratio)
        {
            Color pixel = image.GetPixel(x, y);
            int newRed = (int)Math.Round(pixel.R + quantErrorRed * ratio);
            int newGreen = (int)Math.Round(pixel.G + quantErrorGreen * ratio);
            int newBlue = (int)Math.Round(pixel.B + quantErrorBlue * ratio);

            newRed = Math.Min(255, Math.Max(0, newRed));
            newGreen = Math.Min(255, Math.Max(0, newGreen));
            newBlue = Math.Min(255, Math.Max(0, newBlue));

            image.SetPixel(x, y, Color.FromArgb(255, newRed, newGreen, newBlue));
        }



        //playground
        static Bitmap squareBlur(Bitmap image)
        {
            Bitmap outputImage = (Bitmap)image.Clone();

            int blurarea = 7;
            double scale = 1;
            int res = outputImage.Width * outputImage.Height;
            scale = Convert.ToDouble(res) / (1920 * 1080);
            blurarea = ((int)Math.Round(blurarea * scale) % 2 == 0 ? (int)Math.Round(blurarea * scale)+1: (int)Math.Round(blurarea * scale));

            //方框模糊
            for (int y = 0; y < outputImage.Height; y++)
            {
                for (int x = 0; x < outputImage.Width; x++)
                {
                    int colorcount = 0;
                    int colorRtotal = 0;
                    int colorGtotal = 0;
                    int colorBtotal = 0;
                    for (int i = 0; i<Math.Pow(blurarea,2); i++)
                    {
                        int newx = x - (blurarea/2) + i % blurarea;
                        int newy = y - (blurarea/2) + i / blurarea;
                        if(newx >= 0 && newx < outputImage.Width && newy >=0 && newy < outputImage.Height)
                        {
                            Color pixel = outputImage.GetPixel(newx, newy);
                            colorRtotal += pixel.R;
                            colorGtotal += pixel.G;
                            colorBtotal += pixel.B;
                            colorcount++; 
                        }
                    }
                    int bulrvalueR = colorRtotal / colorcount;
                    int bulrvalueG = colorGtotal / colorcount;
                    int bulrvalueB= colorBtotal / colorcount;
                    for (int i = 0; i < Math.Pow(blurarea, 2); i++)
                    {
                        int newx = (blurarea / 2) + i % blurarea;
                        int newy = (blurarea / 2) + i / blurarea;
                        if (newx >= 0 && newx < outputImage.Width && newy >= 0 && newy < outputImage.Height)
                        {
                            outputImage.SetPixel(newx, newy, Color.FromArgb(255, bulrvalueR, bulrvalueG, bulrvalueB));
                        }
                    }
                }
            }

                    return outputImage;
        }
    }

    public class bit10Bitmap
    {
        public class unitBitData
        {
            public int posX { get; set; }
            public int posY { get; set; }
            public ushort A { get; set; }
            public ushort R { get; set; }
            public ushort G { get; set; }
            public ushort B { get; set; }
        }

        public bit10Bitmap(int width = 0, int height = 0)
        {
            _width = width;
            _height = height;
            bit10BmpData = new unitBitData[width * height];
        }

        private unitBitData[] bit10BmpData = { };

        private int _width = 0;
        private int _height = 0;
        public int Width { get => _width; }
        public int Height { get => _height; }

        public void bit8Transbit10(Bitmap origimBmp)
        {
            _width = origimBmp.Width;
            _height = origimBmp.Height;
            bit10BmpData = new unitBitData[Width * Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    unitBitData unitPixel = new unitBitData();
                    unitPixel.posX = x;
                    unitPixel.posY = y;
                    var argb = origimBmp.GetPixel(x, y);
                    unitPixel.A = (ushort)Math.Round(argb.A * 1023.0 / 255.0);
                    unitPixel.R = (ushort)Math.Round(argb.R * 1023.0 / 255.0);
                    unitPixel.G = (ushort)Math.Round(argb.G * 1023.0 / 255.0);
                    unitPixel.B = (ushort)Math.Round(argb.B * 1023.0 / 255.0);
                    bit10BmpData[y * Width + x] = unitPixel;
                }
            }
        }

        public unitBitData GetPixel(int x, int y)
        {
            int index = y * Width + x;
            return bit10BmpData[index];
        }

        public void SetPixel(int x, int y, ushort A, ushort R, ushort G, ushort B)
        {
            int index = y * Width + x;
            if (bit10BmpData[index] == null)
            {
                bit10BmpData[index] = new unitBitData();
            }
            bit10BmpData[index].A = A;
            bit10BmpData[index].R = R;
            bit10BmpData[index].G = G;
            bit10BmpData[index].B = B;
        }

        public Bitmap bit10TransBmp()
        {
            Bitmap bitmap = new Bitmap(Width, Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    unitBitData pixelData = GetPixel(x, y);

                    // 將 10 位元的通道值轉換為 8 位元的範圍（0 到 255）
                    int a = (int)Math.Round(pixelData.A * 255.0 / 1023.0);
                    int r = (int)Math.Round(pixelData.R * 255.0 / 1023.0);
                    int g = (int)Math.Round(pixelData.G * 255.0 / 1023.0);
                    int b = (int)Math.Round(pixelData.B * 255.0 / 1023.0);

                    // 確保每個通道值在合法範圍內
                    a = Math.Max(0, Math.Min(255, a));
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    // 創建新的 Color 物件並設定像素
                    Color color = Color.FromArgb(a, r, g, b);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }
    }
}
