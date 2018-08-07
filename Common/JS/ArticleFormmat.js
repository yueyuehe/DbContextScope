$(function () {
    this_load()
});
function this_load() {
    UE.getEditor('content');
    $("#this_format").bind("click",
    function () {
        this_format_do();
    });
    $("#this_convert").bind("click",
    function () {
        this_convert_do();
    });
    $("#this_reconvert").bind("click",
    function () {
        this_reconvert_do();
    });
    $("#this_reset").bind("click",
    function () {
        this_reset_do();
    });
}
function formatText() {
    var content = UE.getEditor('content').getContent();
    //清除脚本
    if ($('#clearScript').length > 0 && $('#clearScript').is(':checked')) {
        content = content.replace(/\<\!\-\-(.*?)\-\-\>/gi, '');
        content = content.replace(/<[\s]*(script)[^>]*>.*?<[\s]*\/[\s]*(script)[\s]*>/gi, '');
        content = content.replace(/<[\s]*(style|title)[^>]*>.*?<[\s]*\/[\s]*(style|title)[\s]*>/gi, '');
        content = content.replace(/<[\s]*(meta|link|base)[^>]*>/gi, '');
    }
    //清除对象
    if ($('#clearObject').length > 0 && $('#clearObject').is(':checked')) {
        content = content.replace(/<[\s]*(object)[^>]*>.*?<[\s]*\/[\s]*(object)[\s]*>/gi, '');
        content = content.replace(/<[\s]*(embed|bgsound)[^>]*>/gi, '');
    }
    //清除属性
    if ($('#clearAttr').length > 0 && $('#clearAttr').is(':checked')) {
        content = content.replace(/(id|class|style|onclick|alt|title|width|height|_href|_src)\s*\=\'[^\>\']*?\'/gi, '');
        content = content.replace(/(id|class|style|onclick|alt|title|width|height|_href|_src)\s*\=\"[^\>\"]*?\"/gi, '');
        //content = content.replace(/(id|class|style|onclick|alt|title|width|height|_href|_src)\s*\=[^\>\s]+?/gi,''); 
    }
    //行格式化
    if ($('#clearLine').length > 0 && $('#clearLine').is(':checked')) {
        content = content.replace(/[\s]+/gi, ' ');
        content = content.replace(/[\s]+>/gi, '>');
        content = content.replace(/<([\/\s]*)(div)([^>]*)>/gi, '<$1p$3>');
        content = content.replace(/(<([\/\s]*)([^>]*)>)(\s|&nbsp;|\　|\ )+/gi, '$1');
        content = content.replace(/(\s*<[\s]*br[^>]*>\s*)+/gi, '<br/>');
        content = content.replace(/(^\s*<[\s]*br[^>]*>|<[\s]*br[^>]*>\s*$)/gi, '');
        content = content.replace(/(<[\/\s]*(p|hr|h1|h2|h3|h4|h5|h6)[^>]*>)\s*(<[\s]*br[^>]*>)/gi, '$1');
        content = content.replace(/(<[\s]*br[^>]*>)\s*(<[\/\s]*(p|hr|h1|h2|h3|h4|h5|h6)[^>]*>)/gi, '$2');
        contentre = content.replace(/<(!=iframe|embed|br|hr|tr|td)[^>]+>\s*<[\s]*\/[\s]*(!=iframe|embed|br|hr|tr|td)[^>]+>/gi, '');
        while (contentre != content) {
            content = contentre;
            contentre = content.replace(/<(!=iframe|embed|br|hr|tr|td)[^>]+>\s*<[\s]*\/[\s]*(!=iframe|embed|br|hr|tr|td)[^>]+>/gi, '');
        }
        content = content.replace(/<([\/\s]*)(p)([^>]*)>(\s*<[^>]*(br)[^>]+>\s*)*<([\/\s]*)\/([\/\s]*)(p)([^>]*)>/gi, '');
        content = content.replace(/(<[\s]*p[^>]*>[\s]*)*(<[\s]*(embed|img|iframe)[^>]*>)([\s]*<[\s]*\/[\s]*p[^>]*>)*/gi, '<p style="text-align: center;">$2</p>');
    }
    //清除连接
    if ($('#clearA').length > 0 && $('#clearA').is(':checked')) {
        content = content.replace(/<([\/\s]*)(a)([^>]*)>/gi, '');
        //content = content.replace(/<([\/\s]*)(a)([^>]*)(!=href\=\"\/|href\=\'\/|href\=\/)([^>]*)>/gi,'');
    }
    //清除图片
    if ($('#clearImg').length > 0 && $('#clearImg').is(':checked')) {
        content = content.replace(/<([\/\s]*)(img)([^>]*)>/gi, '');
    }
    // UE.getEditor('content').setContent(content);

    alert('任务已处理！');
}
function this_format_do() {
    var data = $('#this_form').serializeArray();
    update_serializeArray(data, 'content', UE.getEditor('content').getContent());
    $.ajax({
        type: 'post',
        url: '/index.php?qi=content.editor.format',
        data: data,
        cache: false,
        dataType: 'json',
        success: function (data, textStatus) {
            if (data.success) {
                UE.getEditor('content').setContent(data.content);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            this_error();
        }
    });
}
function this_convert_do() {
    var data = $('#this_form').serializeArray();
    update_serializeArray(data, 'content', UE.getEditor('content').getContent());
    $.ajax({
        type: 'post',
        url: '/index.php?qi=content.editor.convert',
        data: data,
        cache: false,
        dataType: 'json',
        success: function (data, textStatus) {
            if (data.success) {
                UE.getEditor('content').setContent(data.content);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            this_error();
        }
    });
}
function this_reconvert_do() {
    var data = $('#this_form').serializeArray();
    update_serializeArray(data, 'content', UE.getEditor('content').getContent());
    $.ajax({
        type: 'post',
        url: '/index.php?qi=content.editor.reconvert',
        data: data,
        cache: false,
        dataType: 'json',
        success: function (data, textStatus) {
            if (data.success) {
                UE.getEditor('content').setContent(data.content);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            this_error();
        }
    });
}
function this_reset_do() {
    UE.getEditor('content').setContent('');
    return true;
}