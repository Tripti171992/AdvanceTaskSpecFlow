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

    var data = {"OkPercent": 98.41111111111111, "KoPercent": 1.5888888888888888};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9555555555555556, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Add Language Request"], "isController": false}, {"data": [0.995, 500, 1500, "Update Education Request"], "isController": false}, {"data": [0.998, 500, 1500, "SigIn Request"], "isController": false}, {"data": [0.999, 500, 1500, "Deactivate Share Skill Request"], "isController": false}, {"data": [0.998, 500, 1500, "View Share Skill Request"], "isController": false}, {"data": [0.999, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [0.999, 500, 1500, "Update Language Request"], "isController": false}, {"data": [0.714, 500, 1500, "Delete Certifications Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill Request"], "isController": false}, {"data": [0.498, 500, 1500, "Search Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education Request"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 9000, 143, 1.5888888888888888, 162.44122222222225, 39, 1857, 116.0, 254.0, 863.9499999999989, 952.0, 29.790868105896607, 17.03614519303655, 20.020239171019444], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Language Request", 500, 0, 0.0, 54.389999999999986, 43, 240, 51.0, 60.0, 67.0, 116.94000000000005, 1.674520166246362, 0.3385016351689423, 0.9909758015090775], "isController": false}, {"data": ["Update Education Request", 500, 0, 0.0, 268.9819999999997, 126, 1325, 273.0, 322.0, 347.0, 524.5000000000005, 1.6741108797117852, 0.3558989703381034, 1.2245205555704366], "isController": false}, {"data": ["SigIn Request", 500, 0, 0.0, 178.486, 145, 889, 166.0, 208.90000000000003, 228.79999999999995, 390.27000000000066, 1.670787943594199, 0.8027613947737753, 0.5837706968856513], "isController": false}, {"data": ["Deactivate Share Skill Request", 500, 0, 0.0, 141.46400000000006, 116, 653, 136.0, 158.90000000000003, 175.89999999999998, 252.93000000000006, 1.674088458834165, 0.31062188201024543, 0.9563884261894398], "isController": false}, {"data": ["View Share Skill Request", 500, 0, 0.0, 96.67200000000004, 78, 1042, 91.0, 106.0, 116.94999999999999, 157.87000000000012, 1.6743463351907415, 2.1499915026923486, 0.9205634635863158], "isController": false}, {"data": ["Delete Language Request", 500, 0, 0.0, 50.064000000000036, 39, 560, 48.0, 55.0, 62.0, 93.92000000000007, 1.6752439155140988, 0.3238717651039991, 1.0502994079688002], "isController": false}, {"data": ["Update Language Request", 500, 0, 0.0, 131.53200000000004, 81, 1145, 99.5, 192.0, 207.89999999999998, 292.8100000000002, 1.6750250416243722, 0.3806625268422763, 1.0501621842996554], "isController": false}, {"data": ["Delete Certifications Request", 500, 143, 28.6, 50.20600000000007, 39, 218, 47.0, 57.0, 70.0, 102.98000000000002, 1.6742902683552443, 0.2947306788995894, 0.9875696504751635], "isController": false}, {"data": ["Delete Skill Request", 500, 0, 0.0, 49.333999999999996, 39, 206, 47.0, 55.0, 64.94999999999999, 90.99000000000001, 1.675552681051845, 0.3184040978573032, 1.094672601195004], "isController": false}, {"data": ["Add Certifications Request", 500, 0, 0.0, 152.8819999999999, 87, 321, 143.0, 186.0, 197.95, 244.96000000000004, 1.674094063997268, 0.33841549926507275, 1.1002590869825795], "isController": false}, {"data": ["Delete Education Request", 500, 0, 0.0, 49.18599999999999, 39, 135, 47.0, 55.0, 68.94999999999999, 88.96000000000004, 1.6746491610007703, 0.35651710654117963, 0.9877813410590481], "isController": false}, {"data": ["Delete Share Skill Request", 500, 0, 0.0, 186.90799999999987, 158, 496, 181.5, 208.0, 226.84999999999997, 278.95000000000005, 1.67352253063383, 0.3203226718791315, 0.9658709136763608], "isController": false}, {"data": ["Update Skill Request", 500, 0, 0.0, 139.32600000000008, 79, 344, 122.5, 196.0, 213.0, 260.99, 1.6746772059685495, 0.36366989286252577, 1.0941006355399996], "isController": false}, {"data": ["Search Skill Request", 500, 0, 0.0, 918.4779999999996, 833, 1857, 898.0, 980.0, 1056.8, 1271.4500000000005, 1.6692372920964953, 9.148202815669464, 1.2160654491249858], "isController": false}, {"data": ["Add Skill Request", 500, 0, 0.0, 52.01199999999999, 41, 144, 50.0, 58.0, 71.94999999999999, 100.98000000000002, 1.674935263752056, 0.3385855464811285, 1.045198860876527], "isController": false}, {"data": ["Add Description Request", 500, 0, 0.0, 143.99600000000007, 121, 313, 138.0, 165.90000000000003, 188.84999999999997, 250.0, 1.67372420372571, 0.3595891843941955, 0.9888702570840376], "isController": false}, {"data": ["Add Share Skill Request", 500, 0, 0.0, 98.604, 81, 405, 94.0, 111.90000000000003, 123.0, 167.91000000000008, 1.6739315295047172, 0.3661725220791569, 2.8558187324655675], "isController": false}, {"data": ["Add Education Request", 500, 0, 0.0, 161.41999999999987, 87, 364, 152.0, 198.0, 211.95, 274.7900000000002, 1.6746267257028409, 0.33852317599657034, 1.1365874749643303], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 143, 100.0, 1.5888888888888888], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 9000, 143, "500/Internal Server Error", 143, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certifications Request", 500, 143, "500/Internal Server Error", 143, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
