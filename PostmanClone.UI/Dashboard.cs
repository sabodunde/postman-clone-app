using PostmanClone.Library;

namespace PostmanClone.UI;

public partial class Dashboard : Form
{
    private readonly IApiAccess api = new ApiAccess();

    public Dashboard()
    {
        InitializeComponent();
    }

    private async void callApi_Click(object sender, EventArgs e)
    {
        systemStatus.Text = "Calling API...";
        resultsText.Text = "";


        // Validate the API URL
        if (api.IsValidUrl(apiText.Text) == false)
        {
            systemStatus.Text = "Invalid URL";
            
            return;
        }

        try
        {
            // Sample code - replace with the actual API call
            resultsText.Text = await api.CallApiAsync(apiText.Text);

            systemStatus.Text = "Ready";
        }
        catch (Exception ex) 
        {
            resultsText.Text = "Error" + ex.Message;
            systemStatus.Text = "Error";
        }
    }
}
