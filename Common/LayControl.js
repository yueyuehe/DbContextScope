

var $ = layui.jquery;

//table 表格数量
var layTableControls = $("table").filter("[layui]");

//tree 数量
var layTreeControls = $("ul").filter("[layui]");

// 树形下拉选择框
var laySelectTreeControls = $("input").filter("[layui]");

//全局 外部可访问 layTable.ID名称 用于再次渲染

/**
* layui 表格
**/
var layTable = {};

if (layTableControls.length > 0) {
    layui.use('table', function () {
        var table = layui.table;
        for (var i = 0; i < layTableControls.length; i++) {
            var controlID = layTableControls[i].attr("id");
            var optionsStr = layTableControls[i].attr("lay-options");
            var options = JSON.parse(optionsStr);
            options.elem = "#" + controlID;
            layTable[controlID] = table.render(options);
        }
    });
}


/**
*layTree
*/

var layTree = new Array();

if (layTreeControls.length > 0) {
    layui.use('tree', function () {
        for (var i = 0; i < layTreeControls.length; i++) {
            var controlID = layTreeControls[i].attr("id");
            var optionsStr = layTreeControls[i].attr("lay-options");
            var options = JSON.parse(optionsStr);
            options.elem = "#" + controlID;
            layTable[controlID] = layui.tree(options);
        }
    });
}













