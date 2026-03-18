using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Services
{
    public class PaynimoHtmlBuilder
    {
        public static string BuildCheckoutHtml(object configJson)
        {
            string configJsonString = JsonConvert.SerializeObject(configJson);

            return $@"
            <!doctype html>
            <html>
            <head>
                <title>Checkout Demo</title>
                <meta name='viewport' content='user-scalable=no, width=device-width, initial-scale=1' />
                <script src='https://www.paynimo.com/Paynimocheckout/client/lib/jquery.min.js'></script>
            </head>

            <body>

            

            <script src='https://www.paynimo.com/Paynimocheckout/server/lib/checkout.js'></script>

            <script>
            $(document).ready(function() {{

                function handleResponse(res) {{
                    if (res && res.paymentMethod && res.paymentMethod.paymentTransaction &&
                        res.paymentMethod.paymentTransaction.statusCode === '0300') {{
                        console.log('SUCCESS');
                    }} else if (res && res.paymentMethod && res.paymentMethod.paymentTransaction &&
                        res.paymentMethod.paymentTransaction.statusCode === '0398') {{
                        console.log('INITIATED');
                    }} else {{
                        console.log('FAILED');
                    }}
                }}

                var configJson = {configJsonString};

                configJson.consumerData.responseHandler = handleResponse;

                $.pnCheckout(configJson);

                if (configJson.features.enableNewWindowFlow) {{
                    pnCheckoutShared.openNewWindow();
                }}
            }});
            </script>

            </body>
            </html>";
        }
    }
}
