if (!String.prototype.trim) {
	String.prototype.trim = function () { return this.replace(/^\s+|\s+$/g, ''); };
}

if (!String.prototype.ltrim) {
	String.prototype.ltrim = function () { return this.replace(/^\s+/, ''); };
}

if (!String.prototype.rtrim) {
	String.prototype.rtrim = function () { return this.replace(/\s+$/, ''); };
}

if (!String.prototype.fulltrim) {
	String.prototype.fulltrim = function () { return this.replace(/(?:(?:^|\n)\s+|\s+(?:$|\n))/g, '').replace(/\s+/g, ' '); };
}

String.prototype.format = function () {
	var args = arguments;
	return this.replace(/{(\d+)}/g, function (match, number) {
		return parseInt(number) < args.length ? args[number] : match;
	});
};

String.prototype.replaceAll = function (search, replacement) {
	var target = this;
	search = search.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
	return target.replace(new RegExp(search, 'g'), replacement);
};

if (!String.prototype.endsWith) {
	String.prototype.endsWith = function (searchString, position) {
		position = position || this.length;
		position = position - searchString.length;
		var lastIndex = this.lastIndexOf(searchString);
		return lastIndex !== -1 && lastIndex === position;
	};
}

if (!String.prototype.startsWith) {
	String.prototype.startsWith = function (searchString, position) {
		position = position || 0;
		return this.indexOf(searchString, position) === position;
	};
}

if (!String.prototype.unescapeXml) {
	String.prototype.unescapeXml = function () {
		if ($("html.k-ie8").length) {
			return $('<div/>').html(this.replace(/(\r\n|\r|\n)/g, "____BREAK____")).text().replace(/____BREAK____/g, "\r\n");
		}
		else {
			return $('<div/>').html(this).text();
		}
	};
}

if (!String.prototype.decodeBase64) {
	String.prototype.decodeBase64 = function () {
		var e = {}, i, b = 0, c, x, l = 0, a, r = '', w = String.fromCharCode, length = this.length;
		var A = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
		for (i = 0; i < 64; i++) {
			e[A.charAt(i)] = i;
		}
		for (x = 0; x < length; x++) {
			c = e[this.charAt(x)];
			b = (b << 6) + c;
			l += 6;
			while (l >= 8) {
				((a = (b >>> (l -= 8)) & 0xff) || (x < (length - 2))) && (r += w(a));
			}
		}
		return r;
	}
}

if (!String.prototype.regexIndexOf) {
	String.prototype.regexIndexOf = function (regex, startpos) {
		var indexOf = this.substring(startpos || 0).search(regex);
		return (indexOf >= 0) ? (indexOf + (startpos || 0)) : indexOf;
	}
}

if (!String.prototype.regexLastIndexOf) {
	String.prototype.regexLastIndexOf = function (regex, startpos) {
		regex = (regex.global) ? regex : new RegExp(regex.source, "g" + (regex.ignoreCase ? "i" : "") + (regex.multiLine ? "m" : ""));
		if (typeof (startpos) == "undefined") {
			startpos = this.length;
		}
		else if (startpos < 0) {
			startpos = 0;
		}
		var stringToWorkWith = this.substring(0, startpos + 1);
		var lastIndexOf = -1;
		var nextStop = 0;
		var result;
		while ((result = regex.exec(stringToWorkWith)) != null) {
			lastIndexOf = result.index;
			regex.lastIndex = ++nextStop;
		}
		return lastIndexOf;
	}
}
