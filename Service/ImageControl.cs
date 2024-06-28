using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh.Service
{
    internal class ImageControl
    {
        public static Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // 원본 이미지의 비율 계산
            float ratioX = (float)newWidth / originalImage.Width;
            float ratioY = (float)newHeight / originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            // 새로운 크기 계산
            int width = (int)(originalImage.Width * ratio);
            int height = (int)(originalImage.Height * ratio);

            // 새로운 이미지 생성
            Bitmap resizedImage = new Bitmap(width, height);

            // 그래픽 객체 생성
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // 그래픽 속성 설정
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // 이미지의 해상도 정보 설정
                resizedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

                // 이미지 그리기
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            // 크기가 조절된 이미지 반환
            return resizedImage;
        }
        public static Image RotateImage(Image originalImage)
        {
            // 새로운 이미지 생성
            Bitmap rotatedImage = new Bitmap(originalImage.Height, originalImage.Width);

            // 그래픽 객체 생성
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                // 그래픽 속성 설정
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // 이미지의 해상도 정보 설정
                rotatedImage.SetResolution(originalImage.VerticalResolution, originalImage.HorizontalResolution);

                // 이미지를 90도 회전하여 그리기
                graphics.TranslateTransform(0, originalImage.Width);
                graphics.RotateTransform(-90.0f);
                graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height));
            }

            // 회전된 이미지 반환
            return rotatedImage;
        }
    }
}
