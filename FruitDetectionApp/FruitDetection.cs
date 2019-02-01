using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.AI.MachineLearning.Preview;

// f876f131-36c5-4740-a3e1-1875de50401c_feb3f391-dbad-4a35-8223-918672c408b3

namespace FruitDetectionApp
{
    public sealed class FruitDetectionModelInput
    {
        public VideoFrame data { get; set; }
    }

    public sealed class FruitDetectionModelOutput
    {
        public IList<string> classLabel { get; set; }
        public IDictionary<string, float> loss { get; set; }
        public FruitDetectionModelOutput()
        {
            this.classLabel = new List<string>();
            this.loss = new Dictionary<string, float>()
            {
                { "apple", float.NaN },
                { "cherry", float.NaN },
                { "kiwi", float.NaN },
                { "orange", float.NaN },
                { "pineapple", float.NaN },
                { "strawberry", float.NaN },
            };
        }
    }

    public sealed class FruitDetectionModel
    {
        private LearningModelPreview learningModel;
        public async Task<FruitDetectionModel> CreateFruitDetectionModel(StorageFile file)
        //public static async Task<FruitDetectionModel> CreateFruitDetectionModel(StorageFile file)
        {
            LearningModelPreview learningModel = await LearningModelPreview.LoadModelFromStorageFileAsync(file);
            FruitDetectionModel model = new FruitDetectionModel();
            model.learningModel = learningModel;
            return model;
        }
        public async Task<FruitDetectionModelOutput> EvaluateAsync(FruitDetectionModelInput input) {
            FruitDetectionModelOutput output = new FruitDetectionModelOutput();
            LearningModelBindingPreview binding = new LearningModelBindingPreview(learningModel);
            binding.Bind("data", input.data);
            binding.Bind("classLabel", output.classLabel);
            binding.Bind("loss", output.loss);
            LearningModelEvaluationResultPreview evalResult = await learningModel.EvaluateAsync(binding, string.Empty);
            return output;
        }
    }
}
