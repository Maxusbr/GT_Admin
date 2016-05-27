(function () {
    'use strict';


    angular
        .module('app')
        .controller('MainUserProfileController', MainUserProfileController);

    MainUserProfileController.$inject = ['$rootScope', '$stateParams', '$filter'];
    function MainUserProfileController($rootScope, $stateParams, $filter) {
        var vm = this;
        $rootScope.peSortType = 'date'; // set the default sort type
        $rootScope.peSortReverse = false;  // set the default sort order
        $rootScope.paSortType = 'date'; // set the default sort type
        $rootScope.paSortReverse = true;  // set the default sort order

        $rootScope.user = {"email": "qwe@qwe.ru"};

        $rootScope.eventslist = [
            {
                "fname": "Хан",
                "sname": "Cоло",
                "email": "anni@forceiscomming.com",
                "phone": "+7 (495) 6968899",
                "company": "ЗАО Миллениум Фэлкон",
                "event": "1/5 Бой за звание чемпиона мира по боксу в супертяжелом весе по версии WBA Лукас Браун...",
                "active": true,
                "role": "Представитель орг.",
                "status": "На событии, Активен, Операционный центр",
                "statusclass": "text-success",
                "date": "5 сентября 2016 16:00 / активно 28 мин.",
                "id": "1"
            },
            {
                "fname": "Энакин",
                "sname": "Скайуокер",
                "email": "anni@forceiscomming.com",
                "phone": "+7 (495) 6968899",
                "company": "ООО Две стороны силы",
                "event": "3 Чемпионат мира по фигурному катанию",
                "active": false,
                "warning": true,
                "role": "Представитель орг.",
                "status": "Запланирована продажа билетов на 20.10.2016",
                "statusclass": "text-muted",
                "date": "30 сентября 2016 11:00",
                "id": "2"

            },
            {
                "fname": "Дарт",
                "sname": "Вейдер",
                "email": "dart@darksideofforce.com",
                "phone": "+7 (495) 6968899",
                "company": "ОAO Шлемы и Плащи",
                "event": "1/2 Петр налич и биг-бенд \"Песни Утесова и не только...\"",
                "active": true,
                "warning": true,
                "role": "Оператор",
                "status": "На событии, Пауза, Вход \"У женского туалета\"",
                "statusclass": "text-danger",
                "date": "30 сентября 2016 17:30",
                "id": "3"

            },
            {
                "invite": true,
                "email": "dart@darksideofforce.com",
                "phone": "+7 (495) 6968899",
                "company": "-",
                "event": "-",
                "active": false,
                "role": "Организатор",
                "status": "Отправлено приглашение 25.07.2016 18:43",
                "statusclass": "text-primary",
                "id": "4"

            },
            {
                "fname": "Григори",
                "sname": "Хаус",
                "email": "grag@housemd.com",
                "phone": "+7 (495) 6968899",
                "company": "ИП Викодиныч",
                "event": "8 А.Кролл, Л.Ролл, М. Волл День джаза в Доме музыки. \"Все цвета московского джаза\"",
                "active": false,
                "role": "Старший оператор",
                "status": "Назначен на вход, Вход 17",
                "statusclass": "",
                "date": "10 октября 2016 16:00",
                "id": "5"

            },
            {
                "fname": "Надежда",
                "sname": "Новая",
                "email": "newhope@voinazvezda.ru",
                "phone": "+7 (495) 6968899",
                "company": "ООО Шум о Звездах",
                "event": "-",
                "active": false,
                "role": "Старший оператор",
                "status": "",
                "statusclass": "",
                "button": "Акцепт регистрации",
                "id": "6"

            },
        ]
        $rootScope.profileActivity = [
            {
                "description": "Вход 17, Сканирование, Не распознан штрих-код",
                "date": "5 сентября 2016 16:01:47",
                "active": true,
                "id": "1"
            },
            {
                "description": "Вход 17, Сканирование, Успех, Ряд 12, Место 14",
                "date": "5 сентября 2016 16:01:02",
                "active": true,
                "id": "1"
            },
            {
                "description": "Активация входа, Успех, Вход 17",
                "date": "5 сентября 2016 14:53:34",
                "active": true,
                "id": "1"
            },
            {
                "description": "Авторизация в системе, Успех, Сессия - 17 минут",
                "date": "2 сентября 2016 16:00",
                "active": false,
                "id": "1"
            },
        ];
        $rootScope.users = [
            {
                "name": "Усманов Алишер",
                "id": "1"
            },
            {
                "name": "Монро Мэрилин",
                "id": "2"
            },
            {
                "name": "Филькинштейн Евгений",
                "id": "3"
            },
            {
                "name": "Емельяненько Федор",
                "id": "4"
            },
            {
                "name": "Поветкин Александр",
                "id": "5"
            },
            {
                "name": "Липницкая Юлия",
                "id": "6"
            },
            {
                "name": "Джонсон Брайн",
                "id": "7"
            },
        ];
        var filtered = $filter('filter')($rootScope.users, {id: $stateParams.id});
        $rootScope.person = filtered.length ? filtered[0] : null;

        // $rootScope.person = $rootScope.users[$stateParams.id];
    }

})();
