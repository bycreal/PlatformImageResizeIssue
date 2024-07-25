using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace PlatformImageResizeIssue
{
    internal class ResizeImageDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            IImage image;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("PlatformImageResizeIssue.Resources.Images.img_0111.heic"))
            {
                image = PlatformImage.FromStream(stream);
            }

            if (image != null)
            {
                IImage newImage = image.Resize(400, 300, ResizeMode.Stretch, true);
                canvas.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
            }
        }
    }
    internal class DownsizeImageDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            IImage image;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("PlatformImageResizeIssue.Resources.Images.img_0111.heic"))
            {
                image = PlatformImage.FromStream(stream);
            }

            if (image != null)
            {
                IImage newImage = image.Downsize(400, 300);
                canvas.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
            }
        }
    }

}
