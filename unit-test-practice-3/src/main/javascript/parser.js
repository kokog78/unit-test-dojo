import data from './data.js'

function parse(input) {
    var result = [null, null, null];
    var current = '';
    var lookup = false;
    for (var i=0; i<input.length; i++) {
        switch (input.charAt(i)) {
            case ' ':
            case '\t':
                lookup = !!current;
                break;
            case '\n':
            case '\r':
                lookup = current.length>0;
                break;
            default:
                lookup = false;
                current += input.charAt(i);
        }
        if (lookup) {
            update(result, current);
            current = '';
            lookup = false;
        }
    }
    if (!!current) {
        update(result, current);
    }
    return result;
}

function update(array, part) {
    var what = lookup(part);
    switch (what) {
        case 2:
            if (!array[2]) {
                array[2] = '';
            }
            if (array[2].length>0) {
                array[2] += ' ';
            }
            array[2] += part;
            break;
        case 0:
            if (!array[0]) {
                array[0] = part;
            } else {
                if (!array[2]) {
                    array[2] = '';
                }
                if (array[2].length>0) {
                    array[2] += ' ';
                }
                array[2] += part;
            }
            break;
        case 1:
            if (!array[1]) {
                array[1] = part;
            } else {
                if (!array[2]) {
                    array[2] = '';
                }
                if (array[2].length>0) {
                    array[2] += ' ';
                }
                array[2] += part;
            }
            break;
    }
}

function lookup(part) {
    if (!part) {
        return -1;
    }
    var ok = true;
    for (var i=0; i<part.length; i++) {
        switch(part.charAt(i)) {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                break;
            default:
                ok = false;
        }
    }
    if (ok && part.length===4) {
        return 0;
    }
    if (isThere(part)) {
        return 1;
    }
    return 2;
}

function isThere(part) {
    var ok = false;
    for (var i=0; i<data.length; i++) {
        var line = data[i];
        if (line === part) {
            ok = true;
        }
    }
    return ok;
}

export function Parser() {
    this.parse = parse;
}