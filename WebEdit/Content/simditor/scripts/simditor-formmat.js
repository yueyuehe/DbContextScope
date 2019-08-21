(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module unless amdModuleId is set
        define('simditor-formmat', ["jquery", "simditor"], function (a0, b1) {
            return (root['SimditorFormmat'] = factory(a0, b1));
        });
    } else if (typeof exports === 'object') {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(require("jquery"), require("simditor"));
    } else {
        root['SimditorFormmat'] = factory(jQuery, Simditor);
    }
}(this, function ($, Simditor) {

    var SimditorFormmat,
        extend = function (child, parent) { for (var key in parent) { if (hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; },
        hasProp = {}.hasOwnProperty;

    SimditorFormmat = (function (superClass) {
        extend(SimditorFormmat, superClass);

        function SimditorFormmat() {
            return SimditorFormmat.__super__.constructor.apply(this, arguments);
        }

        SimditorFormmat.cls = 'simditor-fullscreen';

        SimditorFormmat.i18n = {
            'zh-CN': {
                formmat: '格式化'
            }
        };

        SimditorFormmat.prototype.name = 'formmat';

        SimditorFormmat.prototype.needFocus = false;

        SimditorFormmat.prototype.iconClassOf = function () {
            return 'icon-formmat';
        };

        SimditorFormmat.prototype._init = function () {
            SimditorFormmat.__super__._init.call(this);
            this.window = $(window);
            this.body = $('body');
            this.editable = this.editor.body;
            return this.toolbar = this.editor.toolbar.wrapper;
        };

        SimditorFormmat.prototype.status = function () {
            return this.setActive(this.body.hasClass(this.constructor.cls));
        };

        SimditorFormmat.prototype.command = function () {
            var editablePadding, isFullscreen;
            this.body.toggleClass(this.constructor.cls);
            isFullscreen = this.body.hasClass(this.constructor.cls);
            if (isFullscreen) {
                editablePadding = this.editable.outerHeight() - this.editable.height();
                this.window.on("resize.simditor-formmat-" + this.editor.id, (function (_this) {
                    return function () {
                        return _this._resize({
                            height: _this.window.height() - _this.toolbar.outerHeight() - editablePadding
                        });
                    };
                })(this)).resize();
            } else {
                this.window.off("resize.simditor-formmat-" + this.editor.id).resize();
                this._resize({
                    height: 'auto'
                });
            }
            return this.setActive(isFullscreen);
        };

        SimditorFormmat.prototype._resize = function (size) {
            return this.editable.height(size.height);
        };

        return SimditorFormmat;

    })(Simditor.Button);

    Simditor.Toolbar.addButton(SimditorFormmat);

    return SimditorFormmat;

}));

