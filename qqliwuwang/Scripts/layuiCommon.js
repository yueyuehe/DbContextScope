
///弹出层
window.layerOpen = function (title, url, width, height) {
    layer.open({
        type: 2,
        title: title,
        closeBtn: 1, //不显示关闭按钮
        shade: [0.3],
        area: [width, height],
        anim: 0,
        shadeClose: false,
        //iframe的url，no代表不显示滚动条
        content: url,
    });
}

//消息提示框
window.layerAlert = function (message) {
    layer.alert(message, { closeBtn: 0 });
}

//ajax方式上传文件
window.ajaxUpload = function (exp, upUrl, data, successFunc, errorFunc) {
    var model = {
        "url": upUrl,  //这里是服务器处理的代码
        "type": 'post',
        "secureuri": false, //一般设置为false
        "fileElementId": exp, // 上传文件的id、name属性名
        "dataType": 'json', //返回值类型，一般设置为json、application/json
        "data": data, //传递参数到服务器
        "success": successFunc,
        "error": errorFunc
    }
    if (typeof (successFunc) == "function") {
        model.success = successFunc;
    }
    if (typeof (errorFunc) == "function") {
        model.error = errorFunc;
    }
    $.ajaxFileUpload(model);


}