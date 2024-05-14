using Printer.MAUI.Helpers;

namespace Printer.MAUI;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    async void btnPrintPDF_Clicked(object sender, EventArgs e)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(@"https://gbihr.org/images/docs/test.pdf");

        var pdfDocumentStream = await response.Content.ReadAsStreamAsync();
        var fileName = "test.pdf";
        var helper = new PrintHelper();

#if ANDROID
        await helper.PrintAsync(pdfDocumentStream, fileName);

#elif __IOS__ || MACCATALYST
		helper.Print(pdfDocumentStream, fileName);

#endif
    }

}


