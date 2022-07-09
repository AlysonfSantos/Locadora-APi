
using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Domain.Models;
using OfficeOpenXml;

namespace Locadora.Application.ViewModels.UploadArquivosViewModel
{
    public class ReadUploadArquivoViewModel
    {
        public static List<FilmeViewModel> LerArquivoFilmes (MemoryStream stream)
        {
            var ListarFilme = new List<FilmeViewModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[PositionID: 0];
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                for (int row = 2; row <= rowCount; row++)
                {
                    var filme = new FilmeViewModel();
                    filme.Id = Convert.ToInt32(worksheet.Cells[row, Col: 1].Value);
                    filme.Titulo = worksheet.Cells[row, Col: 2].Value.ToString();
                    filme.ClassificacaoIndicativa = Convert.ToInt32(worksheet.Cells[row, Col: 3].Value);
                    filme.Lancamento = Convert.ToInt32(worksheet.Cells[row, Col: 4].Value) == 1 ? true : false;
                    ListarFilme.Add(filme);

                }

            }
            return ListarFilme;
        }
    }
}
