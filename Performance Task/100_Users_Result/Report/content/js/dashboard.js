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

    var data = {"OkPercent": 99.27777777777777, "KoPercent": 0.7222222222222222};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9636111111111111, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Add Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education Request"], "isController": false}, {"data": [0.995, 500, 1500, "SigIn Request"], "isController": false}, {"data": [1.0, 500, 1500, "Deactivate Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "View Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language Request"], "isController": false}, {"data": [0.87, 500, 1500, "Delete Certifications Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill Request"], "isController": false}, {"data": [0.99, 500, 1500, "Add Certifications Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Share Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skill Request"], "isController": false}, {"data": [0.5, 500, 1500, "Search Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skill Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description Request"], "isController": false}, {"data": [1.0, 500, 1500, "Add Share Skill Request"], "isController": false}, {"data": [0.99, 500, 1500, "Add Education Request"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 1800, 13, 0.7222222222222222, 175.79222222222205, 41, 1190, 131.5, 304.0, 880.7999999999993, 975.0, 6.003261772229578, 3.434620049810397, 4.034066842984688], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Add Language Request", 100, 0, 0.0, 57.31000000000002, 46, 103, 55.5, 65.9, 76.89999999999998, 102.81999999999991, 0.3369363055607968, 0.06811114770613763, 0.1993978527049247], "isController": false}, {"data": ["Update Education Request", 100, 0, 0.0, 302.09999999999997, 159, 426, 315.0, 345.0, 362.5999999999999, 425.95, 0.3366391295858665, 0.07161142734149348, 0.24623311333966216], "isController": false}, {"data": ["SigIn Request", 100, 0, 0.0, 215.76999999999995, 160, 691, 201.0, 257.8, 286.9, 688.0499999999985, 0.33660740132354033, 0.16172933735466977, 0.11732608757851368], "isController": false}, {"data": ["Deactivate Share Skill Request", 100, 0, 0.0, 142.21999999999994, 123, 216, 140.0, 155.9, 167.89999999999998, 215.7799999999999, 0.3369612831485662, 0.06252211308420663, 0.19250229554874146], "isController": false}, {"data": ["View Share Skill Request", 100, 0, 0.0, 97.13, 84, 154, 94.0, 111.80000000000001, 122.84999999999997, 153.89999999999995, 0.3369749088482871, 0.43271000697538065, 0.1852703844546735], "isController": false}, {"data": ["Delete Language Request", 100, 0, 0.0, 53.92000000000002, 43, 88, 52.0, 66.0, 75.84999999999997, 87.95999999999998, 0.3369294941340575, 0.06478654042480071, 0.21123899925201653], "isController": false}, {"data": ["Update Language Request", 100, 0, 0.0, 173.0199999999999, 86, 270, 184.5, 220.70000000000002, 242.64999999999992, 269.8599999999999, 0.33686593409554866, 0.0733933495085126, 0.2111991500872483], "isController": false}, {"data": ["Delete Certifications Request", 100, 13, 13.0, 52.87000000000001, 41, 161, 50.5, 59.0, 66.94999999999999, 160.45999999999972, 0.33678538351435544, 0.06426220320788077, 0.1986507535572956], "isController": false}, {"data": ["Delete Skill Request", 100, 0, 0.0, 51.239999999999995, 41, 95, 50.0, 58.0, 63.0, 94.72999999999986, 0.3370669111525329, 0.06406246313330659, 0.2202126597275825], "isController": false}, {"data": ["Add Certifications Request", 100, 0, 0.0, 191.77000000000004, 90, 579, 179.0, 206.9, 400.39999999999895, 578.8799999999999, 0.3367184764162379, 0.06806711388492309, 0.2213003267852814], "isController": false}, {"data": ["Delete Education Request", 100, 0, 0.0, 51.10000000000002, 43, 96, 51.0, 56.0, 58.0, 95.68999999999984, 0.33684777848890085, 0.07171173409236366, 0.1986875568430626], "isController": false}, {"data": ["Delete Share Skill Request", 100, 0, 0.0, 193.67999999999998, 165, 315, 188.0, 213.9, 229.95, 314.76999999999987, 0.3369397113774433, 0.06449236663083875, 0.19446422795319235], "isController": false}, {"data": ["Update Skill Request", 100, 0, 0.0, 144.84000000000006, 85, 285, 120.0, 211.50000000000003, 231.4999999999999, 284.8099999999999, 0.3369022511808424, 0.0732564992655531, 0.22010508402342144], "isController": false}, {"data": ["Search Skill Request", 100, 0, 0.0, 932.0600000000001, 846, 1190, 913.0, 1015.0000000000001, 1062.5499999999997, 1189.8899999999999, 0.3361796544073153, 1.8424220903650912, 0.2449121310428293], "isController": false}, {"data": ["Add Skill Request", 100, 0, 0.0, 57.300000000000004, 44, 104, 54.0, 78.50000000000003, 88.0, 103.93999999999997, 0.3369431172629437, 0.06811252468108334, 0.2102604022763877], "isController": false}, {"data": ["Add Description Request", 100, 0, 0.0, 146.73999999999998, 123, 205, 143.5, 164.8, 174.0, 204.96999999999997, 0.33674568965517243, 0.07234770676185345, 0.198956193595097], "isController": false}, {"data": ["Add Share Skill Request", 100, 0, 0.0, 103.02, 87, 233, 97.0, 126.9, 136.84999999999997, 232.7499999999999, 0.33681033873015764, 0.07367726159722199, 0.5746168571890482], "isController": false}, {"data": ["Add Education Request", 100, 0, 0.0, 198.17, 91, 564, 186.0, 223.50000000000003, 246.04999999999978, 563.8, 0.336912466772008, 0.06810632873223209, 0.22866617617826712], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 13, 100.0, 0.7222222222222222], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 1800, 13, "500/Internal Server Error", 13, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Certifications Request", 100, 13, "500/Internal Server Error", 13, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
