﻿using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace FruitDetectionApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UIPreviewImage.Source = null;
            ResultText.Visibility = Visibility.Collapsed;
            try
            {
                // Get image using FileOpenPicker
                var fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                fileOpenPicker.FileTypeFilter.Add(".jpg");
                fileOpenPicker.FileTypeFilter.Add(".jpeg");
                fileOpenPicker.FileTypeFilter.Add(".png");
                fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
                var selectedStorageFile = await fileOpenPicker.PickSingleFileAsync();

                // Change image to SoftwareBitmap to show in AppPage
                SoftwareBitmap softwareBitmap;
                using (var stream = await selectedStorageFile.OpenAsync(FileAccessMode.Read))
                {
                    var decoder = await BitmapDecoder.CreateAsync(stream);
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                }

                // Show image on AppPage
                var imageSource = new SoftwareBitmapSource();
                await imageSource.SetBitmapAsync(softwareBitmap);
                UIPreviewImage.Source = imageSource;

                // Change image from SoftwareBitmap to VideoFrame
                var inputImage = VideoFrame.CreateWithSoftwareBitmap(softwareBitmap);

                await EvaluateVideoFrameAsync(inputImage);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task EvaluateVideoFrameAsync(VideoFrame inputFrame)
        {
            if (inputFrame != null)
            {
                try
                {
                    // Get ONNX file
                    string modelPath
                        = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "FruitDetection.onnx");
                    var modelFile = await StorageFile.GetFileFromPathAsync(modelPath);

                    // Create WinML Model
                    var model = new FruitDetectionModel();
                    var learninModel = await model.CreateFruitDetectionModel(modelFile);

                    // Set image(VideoFrame)
                    var input = new FruitDetectionModelInput
                    {
                        data = inputFrame
                    };

                    // Detect image
                    var output = await learninModel.EvaluateAsync(input);

                    ResultText.Text = output.classLabel[0];
                    ResultText.Visibility = Visibility.Visible;
                }
                catch(Exception ex)
                {
                }
            }
        }
    }


}

