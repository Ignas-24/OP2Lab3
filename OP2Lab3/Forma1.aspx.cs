using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OP2Lab3
{
    public partial class Forma1 : System.Web.UI.Page
    {
        //result filepath
        readonly string Cfr = HttpContext.Current.Server.MapPath("App_Data\\Rezulatai.txt");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && File.Exists(Cfr))
            {
                File.Delete(Cfr);
                //HttpContext.Current.Response.Write("<script>alert('Failas buvo ištrintas')</script>");
            }
           
        }
        CustomLinkedList<Publication> publications;
        CustomLinkedList<Subscriber> subscribers;
        protected void Button1_Click(object sender, EventArgs e)
        {
            Stream publicationFile = FileUpload1.FileContent;
            Stream subscribersFile = FileUpload2.FileContent;
            publications = InOutUtils.ReadPublications(publicationFile);
            subscribers = InOutUtils.ReadSubscribers(subscribersFile);
            if (publications.Count > 0)
            {

                Label1.Text = "Pradiniai leidiniai";

                if (subscribers.Count > 0)
                {
                    Label7.Text = "";
                    TaskUtils.AddSubscribersToPublications(subscribers, publications);
                    DisplayItemsInTable<Publication>(publications, Table1);
                    InOutUtils.WriteToFile<Publication>(publications, Cfr, "Pradiniai leidiniai");
                    DisplayDataLabels();
                    InOutUtils.WriteToFile<Subscriber>(subscribers, Cfr, "Visi prenumeratoriai");

                    DisplayItemsInTable<Subscriber>(subscribers, Table2);
                    Session["publications"] = publications;
                    Session["subscribers"] = subscribers;
                    CustomLinkedList<Publication> highestEarners = TaskUtils.FindHighestEarnersEveryMonth(publications);
                    double averageIncome = TaskUtils.Average(publications);
                    CustomLinkedList<Publication> belowAverage = TaskUtils.FindBelowAveragePublications(averageIncome, publications);
                    belowAverage.Sort();
                    DisplayItemsInTable<Publication>(belowAverage, Table4);
                    InOutUtils.WriteToFile(belowAverage, Cfr, "Leidiniai kurių pajamos nesiekia vidurkio");
                    DisplayHigestEarnerPublications(highestEarners);
                    InOutUtils.PrintHighestMonthlyEarnears(highestEarners, Cfr, "Daugiausiai pelnę kiekvieną mėnesį");
                    Session["belowAverage"] = belowAverage;
                    Session["highestEarners"] = highestEarners;

                    FillUpMonthDropDown();
                    FillUpPublicationDropDown(publications);
                }
                else
                {
                    DisplayItemsInTable(publications, Table1);
                    InOutUtils.WriteToFile(publications, Cfr, "Pradiniai leidiniai");
                    Label7.Text = "Prenumeratorių įkelti nepavyko";
                }
            }
            else
            {
                Label7.Text = "Leidinių įkelti nepavyko";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            publications = (CustomLinkedList<Publication>)Session["publications"];
            subscribers = (CustomLinkedList<Subscriber>)Session["subscribers"];
            if (publications != null && subscribers != null)
            {
                //displays the tables and labels that were uploded in the first button press
                CustomLinkedList<Publication> highestEarners = (CustomLinkedList<Publication>)Session["highestEarners"];
                CustomLinkedList<Publication> belowAverage = (CustomLinkedList<Publication>)Session["belowAverage"];
                DisplayDataLabels();
                DisplayItemsInTable(belowAverage, Table4);
                DisplayHigestEarnerPublications(highestEarners);
                DisplayItemsInTable(publications, Table1);
                DisplayItemsInTable(subscribers, Table2);

                int month = DropDownList2.SelectedIndex + 1;
                string publicationName = DropDownList1.SelectedValue;

                Publication publication = TaskUtils.FindPublicationByName(publicationName, publications);
                if (publication != null)
                {
                    CustomLinkedList<Subscriber> pickedSubscribers = TaskUtils.FindSubscribersByPublicationId(publication.Id, month, subscribers);
                    if (pickedSubscribers != null)
                    {
                        InOutUtils.WriteToFile(pickedSubscribers, Cfr, String.Format("{0}, {1} mėnesio prenumeratoriai", publicationName, month.ToString()));
                        DisplayItemsInTable(pickedSubscribers, Table5);
                    }
                    else
                    {
                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        cell.Text = "Nerasta prenumeratorių";
                        row.Cells.Add(cell);
                        Table5.Rows.Add(row);
                    }
                }
            }
        }
    }
}