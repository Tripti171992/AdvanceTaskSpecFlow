/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 99.29629629629629, "KoPercent": 0.7037037037037037};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9628703703703704, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.9983333333333333, 500, 1500, "Add Language Request"], "isController": false}, {"data": [0.995, 500, 1500, "Update Education Request"], "isController": false}, {"data": [0.9883333333333333, 500, 1500, "SigIn Request"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Deactivate Share Skill Request"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "View Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language Request"], "isController": false}, {"data": [0.8733333333333333, 500, 1500, "Delete Certifications Request"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Delete Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education Request"], "isController": false}, {"data": [0.9966666666666667, 500, 1500, "Delete Share Skill Request"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Update Skill Request"], "isController": false}, {"data": [0.49166666666666664, 500, 1500, "Search Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Share Skill Request"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Add Education Request"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 5400, 38, 0.7037037037037037, 171.27092592592584, 38, 1767, 125.0, 277.0, 888.0, 964.9899999999998, 17.89027299231381, 10.239777412080905, 12.02258957560297], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Language Request", 300, 0, 0.0, 57.15000000000003, 42, 798, 52.0, 64.0, 74.89999999999998, 126.90000000000009, 1.004187461715353, 0.20299492634284966, 0.5942750017573281], "isController": false}, {"data": ["Update Education Request", 300, 0, 0.0, 291.513333333333, 173, 1096, 292.0, 333.90000000000003, 352.84999999999997, 621.9900000000018, 1.0036600135159548, 0.21353585554488702, 0.7341224122299318], "isController": false}, {"data": ["SigIn Request", 300, 0, 0.0, 214.3, 151, 879, 194.0, 244.0, 290.74999999999994, 815.5100000000004, 1.0031398276605776, 0.4819773390712932, 0.35035442184036036], "isController": false}, {"data": ["Deactivate Share Skill Request", 300, 0, 0.0, 151.79999999999993, 120, 1000, 143.0, 164.90000000000003, 177.95, 370.0900000000008, 1.0038044187470514, 0.1862527730097068, 0.5734624853193604], "isController": false}, {"data": ["View Share Skill Request", 300, 0, 0.0, 103.49999999999996, 81, 1039, 96.5, 107.90000000000003, 118.89999999999998, 215.92000000000007, 1.0039421461605906, 1.2891179259726526, 0.5519720979379028], "isController": false}, {"data": ["Delete Language Request", 300, 0, 0.0, 48.76999999999996, 39, 109, 48.0, 55.900000000000034, 59.0, 79.96000000000004, 1.0042916730829745, 0.19364979575218097, 0.6296438028508493], "isController": false}, {"data": ["Update Language Request", 300, 0, 0.0, 138.91666666666674, 77, 389, 157.0, 188.0, 199.89999999999998, 294.63000000000034, 1.0041370446238502, 0.22362641897116117, 0.6295468580551874], "isController": false}, {"data": ["Delete Certifications Request", 300, 38, 12.666666666666666, 50.23666666666666, 39, 348, 47.0, 56.0, 62.0, 100.97000000000003, 1.0038783165629885, 0.19186755038632583, 0.5921313507852002], "isController": false}, {"data": ["Delete Skill Request", 300, 0, 0.0, 53.92666666666665, 38, 863, 48.0, 55.0, 65.0, 308.2300000000016, 1.004419445560466, 0.19077103317095218, 0.6562076260546404], "isController": false}, {"data": ["Add Certifications Request", 300, 0, 0.0, 166.46000000000004, 86, 303, 170.0, 191.0, 204.95, 270.60000000000036, 1.0037238153549668, 0.20290120095554506, 0.6596739528651296], "isController": false}, {"data": ["Delete Education Request", 300, 0, 0.0, 50.039999999999964, 39, 216, 47.0, 56.0, 67.0, 141.64000000000033, 1.0040328653424588, 0.2137491842232969, 0.5922225104168409], "isController": false}, {"data": ["Delete Share Skill Request", 300, 0, 0.0, 199.94333333333327, 163, 1033, 192.0, 224.0, 240.0, 365.4800000000005, 1.0035727188792098, 0.19209009072297378, 0.5792104266187628], "isController": false}, {"data": ["Update Skill Request", 300, 0, 0.0, 140.87666666666652, 78, 1078, 151.0, 189.0, 198.0, 265.6800000000003, 1.0039723840662889, 0.21707307852235344, 0.655915551699558], "isController": false}, {"data": ["Search Skill Request", 300, 0, 0.0, 941.6800000000004, 848, 1767, 925.0, 986.7, 1008.0, 1650.5400000000004, 1.0009542430450362, 5.485698449188226, 0.7292108059683565], "isController": false}, {"data": ["Add Skill Request", 300, 0, 0.0, 51.34000000000002, 40, 133, 50.0, 56.0, 60.0, 87.95000000000005, 1.0043152076756463, 0.2030207499891199, 0.6267162282272832], "isController": false}, {"data": ["Add Description Request", 300, 0, 0.0, 139.86333333333346, 110, 424, 136.0, 155.90000000000003, 166.0, 274.40000000000055, 1.00355929028287, 0.21560844127171036, 0.5929232134972034], "isController": false}, {"data": ["Add Share Skill Request", 300, 0, 0.0, 106.34333333333336, 82, 480, 101.0, 117.90000000000003, 124.94999999999999, 237.70000000000027, 1.0036902344285825, 0.2195572387812524, 1.712350429244857], "isController": false}, {"data": ["Add Education Request", 300, 0, 0.0, 176.21666666666675, 87, 1037, 177.0, 204.0, 213.89999999999998, 302.6700000000003, 1.0041168792047395, 0.20298065819861433, 0.681505108444623], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 38, 100.0, 0.7037037037037037], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 5400, 38, "500/Internal Server Error", 38, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certifications Request", 300, 38, "500/Internal Server Error", 38, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
