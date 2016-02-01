'use strict';

function traverse(selector) {
    var startNode = document.querySelector(selector);
    traverseNode(startNode, '');
    
    function traverseNode(node, spacing) {
        console.log('%s%s: %s%s',
            spacing,
            node.nodeName.toLowerCase(),
            node.id != '' ? 'id="' + node.id + '" ' : '',
            node.className != '' ? 'class="' + node.className + '"' : '');

        for (var i = 0; i < node.childNodes.length; i++) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }
}

var selector = ".birds";
traverse(selector);
