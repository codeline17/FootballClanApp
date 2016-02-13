(function () {
    Element.prototype.attr = function (a, v) { //Set Attribute
        this.setAttribute(a, v);
        return this;
    };
    window.cEl = function (t) { //Create Element
        return document.createElement(t);
    };
    Element.prototype.tEl = function (t) { //Text Node
        this.appendChild(document.createTextNode(t));
        return this;
    };
    Element.prototype.append = function (s) { //Append Multiple Childs
        if (s.constructor !== Array) {
            this.appendChild(s);
            return this;
        } else if(s.constructor === Array){
            for (var i = 0; i < s.length; i += 1) {
                this.appendChild(s[i]);
            }
            return this;
        } else {
            throw ("Cannot define constructor of argument 1.");
        }
    }
    Element.prototype.wr = function (s) {
        this.wrapper = s;
        return this;
    };
    Element.prototype.listener = function (ev, fn, status) {
        this.addEventListener(ev, fn, status);
        return this;
    }

    String.prototype.format = function () { //String format
        var formatted = this;
        for (var i = 0; i < arguments.length; i++) {
            var regexp = new RegExp("\\{" + i + "'\\}", "gi");
            formatted = formatted.replace(regexp, arguments[i]);
        }
        return formatted;
    }
}());

function convertArrayToObject(s) {
    if (!s) {
        return {}
    }
    var ret = {};
    var l = s.length;
    var i = 0;
    for (; i < l;) {
        ret[s[i]] = {};
        i = i + 1;
    }
    return ret;
}

function convertObjectToArray(s) {
    if (!s) {
        return [];
    }
    if (s.constructor === Object) {
        var a = [];
        a.push(s);
        return a;
    } else if (s.constructor === String) {
        var a = [];
        a.push(s);
        return a;
    }

    return Array.apply(this, s);
}

function errorBox(text) {
    var alert = document.createElement("div");
    alert.className = "alert alert-error";
    alert.innerText = text;

    var dismiss = document.createElement("button");
    dismiss.type = "button";
    dismiss.className = "close";
    dismiss.setAttribute("data-dismiss", "alert");
    dismiss.innerText = "x";

    alert.appendChild(dismiss);

    return alert;
}