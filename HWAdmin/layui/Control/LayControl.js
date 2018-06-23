



layui.use(["table", "tree"], function () {
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
        var table = layui.table;
        for (var i = 0; i < layTableControls.length; i++) {
            var item = $(layTableControls[i]);
            var controlID = item.attr("id");
            var optionsStr = item.attr("lay-options");

            var options = JSON.parse(optionsStr);
            options.elem = "#" + controlID;
            layTable[controlID] = table.render(options);
        }
    }
    /**
    *layTree
    */

    var layTree = new Array();

    if (layTreeControls.length > 0) {
        for (var x = 0; x < layTreeControls.length; x++) {
            var treeItem = $(layTableControls[i]);
            var treeID = treeItem.attr("id");
            var treeOptionsStr = treeItem.attr("lay-options");
            var treeOptions = JSON.parse(treeOptionsStr);
            treeOptions.elem = "#" + treeID;
            layTable[treeID] = layui.tree(treeOptions);
        }
    }
});












