using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace OP2Lab3
{
    /// <summary>
    /// interface used to print formatted tables
    /// </summary>
    public interface IPrintTableGeneraliser
    {
        string Header { get; }
    }
    /// <summary>
    /// interface used to get values for a web table
    /// </summary>
    public interface IWebTableGeneraliser
    {

        IEnumerable<object> CellValues();
    }
    /// <summary>
    /// interface used to get the header of a web table
    /// </summary>
    public interface IWebTableHeader
    {
        TableRow TableHeader { get; }
    }
}