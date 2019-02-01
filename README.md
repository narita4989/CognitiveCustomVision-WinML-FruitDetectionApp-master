# UWP app sample using WindowsML model exported from Cognitive Services Custom Vision

Cognitive Services Custom Vision で作成した WindowsML を利用した UWP アプリ のサンプルコードです。<br/>
マイクロソフトの [Azure Cognitive Services](https://azure.microsoft.com/ja-jp/services/cognitive-services/) は、
ご自身で準備しなくとも、画像の認識や自然言語の分析など、AI・人工知能 (人間の認知(Cognitive)機能) を Web API としてすぐに利用できるサービスです。<br/>
https://microsoft.com/cognitive <br/>
カスタム画像認識モデルを作成できる [Custom Vision](https://azure.microsoft.com/ja-jp/services/cognitive-services/custom-vision-service/) を
利用して作成、Exportした WindowsML (ONNX) をアプリ内 (インターネット接続なし) で利用しています。

*This is sample code of UWP app using WindowsML exported from Cognitive Services Custom Vision.*
*[Azure Cognitive Services](https://azure.microsoft.com/ja-jp/services/cognitive-services/) are cognitive Web API services 
such as image recognition and natural language processing without any prep or building.* <br/>
https://microsoft.com/cognitive <br/>
*This sample app uses WindowsML (ONNX) locally (with no internet connection) which is built and exported using 
[Custom Vision](https://azure.microsoft.com/ja-jp/services/cognitive-services/custom-vision-service/) that is customizable image recognize service.*

![](https://msdnshared.blob.core.windows.net/media/2018/07/bluesky_20180707_08s.png)

## Development Enviroment
こちらのアプリは Windows 10 (Ver 1803) + Visual Studio 2017 (ver 15.7), Visual Studio Tools for AI で開発しています。<br/>
ローカルに保存した後、ビルドを行って必要なコンポーネントを復元してください。

*This app developed using Windows 10 (Ver 1803) + Visual Studio 2017 (ver 15.7), Visual Studio Tools for AI.* <br />
*Saving local dev space this app, build with intalling necessary components.*


## Test this App
[root/test_images/](https://github.com/ayako/CognitiveCustomVision-WinML-FruitDetectionApp/tree/master/test_images) の画像を利用してアプリのテストが可能です。<br/>
*Please use images stored in [root/test_images/](https://github.com/ayako/CognitiveCustomVision-WinML-FruitDetectionApp/tree/master/test_images) for app testing.*

## How to develop
日本語: [Custom Vision の WinML モデル Export を利用した ユニバーサル Windows アプリ の開発](https://blogs.msdn.microsoft.com/bluesky/2018/07/11/developing-universal-windows-app-using-winml-model-exported-from-custom-vision-ja/) <br/>
English: [Developing Universal Windows app using WinML model exported from Custom Vision](https://blogs.msdn.microsoft.com/bluesky/2018/07/11/developing-universal-windows-app-using-winml-model-exported-from-custom-vision-en/)

