(function () {
    'use strict';

    require(['factory'], function(Factory) {
        var factory = Factory.getInstance();
        var container = factory.createContainer();
        container.addToDom();

        document.getElementById('addSectionBtn').onclick = function() {
            var title = document.getElementById('newSectionTitle').value;
            var section = factory.createSection(title);
            container.addSection(section);
            section.addToDom();
        };
    });
}());
