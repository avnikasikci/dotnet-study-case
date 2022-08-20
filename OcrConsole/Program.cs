using Infrastructure.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OcrConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            var newListverti = new vertices { x = 1, y = 1 };

            var newModel = new OcrModel();
            newModel.locale = "tr";
            newModel.description = "asdfasdf";
            //newModel.boundingPoly = new boundingPoly { vertices = new List<vertices>(new vertices { x = 1, y = 1 },new vertices { x = 2, y = 2 }).ToList() };
            newModel.boundingPoly = new boundingPoly { vertices = new List<vertices> { new vertices { x = 1, y = 1 }, new vertices { x = 2, y = 2 } } };
            var jsontest = UtilityJson.JsonSerialize(newModel);

            string allText = System.IO.File.ReadAllText(@"D:\Avni\Projects\ProjectCaseStudy\Kaizen\StudyCase\dotnet-study-case\WebApi\response.json");
            var JsonObj = UtilityJson.JsonDeserialize<List<dynamic>>(allText).ToList();
            var OcrModelList = UtilityJson.JsonDeserialize<List<OcrModel>>(allText).ToList();
            OcrModelList.RemoveAt(0);
            //public virtual IList<NewsAgencyTranslate> translateList { get => (UtilityJson.JsonDeserialize<IList<NewsAgencyTranslate>>(JsonTranslate)); set { JsonTranslate = UtilityJson.JsonSerialize(value); } }
            var temp = 0;
            foreach (var _Ocr in OcrModelList)
            {

            }

            var result = new List<OcrResult>();
            var resultEntity = new OcrResult();

            for (int i = 0; i <= OcrModelList.ToList().Count; i++)
            {
                try
                {
                    var Entity = OcrModelList[i];
                    var EntityNext = OcrModelList[i + 1];
                    var EntityBefore = new OcrModel();
                    if(i >0)
                    {
                        EntityBefore = OcrModelList[i - 1];
                    }
                    
                    var vertice = Entity.boundingPoly.vertices[0].y;
                    var verticeNext = EntityNext.boundingPoly.vertices[0].y;
                    var verticeBefore = EntityBefore.boundingPoly?.vertices[0].y ??0;
                    //var verticeDiffNext = (verticeNext - vertice);
                    var verticeDiffNext = (verticeNext - vertice) <0 ? (verticeNext - vertice) * -1 : (verticeNext - vertice);
                    var verticeDiffBefore = (verticeBefore - vertice) <0 ? (verticeBefore - vertice) * -1 : (verticeBefore - vertice);
                    if (verticeDiffBefore >20)
                    {
                        var resultEntity1 = new OcrResult();
                        resultEntity1.Line = result.ToList().Count() + 1;
                        resultEntity1.Text = Entity.description;
                        result.Add(resultEntity1);

                    }
                    else
                    {
                        var resultLast = result.LastOrDefault();
                        if(resultLast != null)
                        {

                        }
                        var resultEntity2 = new OcrResult();
                        resultEntity2 = result[result.ToList().Count - 1];
                        resultEntity2.Text = resultEntity2.Text +" "+ Entity.description;
                        //result.Add(resultEntity2);

                    }


                }
                catch (Exception e)
                {

                    //throw;
                    Console.WriteLine(e);
                }
            }
            var test = result;

            Console.WriteLine("Hello World!");
        }
    }
}
