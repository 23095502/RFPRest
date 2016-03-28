<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uploading using REST API</title>

    <script type="text/javascript">

        function uploadBlobOrFile(blobOrFile) {
            var client = new XMLHttpRequest();
		    //client.open('POST', 'http://localhost:52202/RFPImport/Service.svc/Upload/' + blobOrFile.name.replace(/./g,'').replace('xlsx','') + '/1');
		    client.open('POST', 'http://localhost:51695/RFPImport/RFPImportRoute.svc/marketrate/marketrate/1',false);
            client.setRequestHeader('Content-length', blobOrFile.size);
		    client.setRequestHeader("Content-Type", "multipart/form-data");
		    
		    /* Check the response status */
		    client.onreadystatechange = function () {
		        alert ("rdystate: " + client.readyState + " status: "   + client.status + " Text: "     + client.statusText);
			    if (client.readyState == 4 && client.status == 200) {
                   alert(client.responseText);
			    }
		    }
		    
		    /* Send to server */
		    client.send(blobOrFile);
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="filePicker" type="file" name="Package"  />
        <br />
        <progress min="0" max="100" value="0">0% complete</progress>
        <br />
        <button title="upload" onclick="uploadBlobOrFile(filePicker.files[0])">
            <span>Upload</span>
        </button>
    </div>
    </form>
</body>
</html>
