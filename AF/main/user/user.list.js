(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserListController', MainUserListController);

    MainUserListController.$inject = ['$rootScope', '$scope', 'userService'];
    function MainUserListController($rootScope, $scope, userService) {
        var vm = this;
        //$rootScope.userlist = [
        //    {
        //        "fname": "Хан",
        //        "sname": "Cоло",
        //        "email": "anni@forceiscomming.com",
        //        "phone": "+7 (495) 6968899",
        //        "company": "ЗАО Миллениум Фэлкон",
        //        "event": "1/5 Бой за звание чемпиона мира по боксу в супертяжелом весе по версии WBA Лукас Браун...",
        //        "active": true,
        //        "role": "Представитель орг.",
        //        "status": "На событии, Активен, Операционный центр",
        //        "statusclass": "text-success",
        //        "id": "1"
        //    },
        //    {
        //        "fname": "Энакин",
        //        "sname": "Скайуокер",
        //        "email": "anni@forceiscomming.com",
        //        "phone": "+7 (495) 6968899",
        //        "company": "ООО Две стороны силы",
        //        "event": "3 Чемпионат мира по фигурному катанию",
        //        "active": false,
        //        "role": "Представитель орг.",
        //        "status": "Запланирована продажа билетов на 20.10.2016",
        //        "statusclass": "text-muted",
        //        "id": "2"
        //    },
        //    {
        //        "fname": "Дарт",
        //        "sname": "Вейдер",
        //        "email": "dart@darksideofforce.com",
        //        "phone": "+7 (495) 6968899",
        //        "company": "ОAO Шлемы и Плащи",
        //        "event": "1/2 Петр налич и биг-бенд \"Песни Утесова и не только...\"",
        //        "active": true,
        //        "role": "Оператор",
        //        "status": "На событии, Пауза, Вход \"У женского туалета\"",
        //        "statusclass": "text-danger",
        //        "id": "3"
        //    },
        //    {
        //        "invite": true,
        //        "email": "dart@darksideofforce.com",
        //        "phone": "+7 (495) 6968899",
        //        "company": "-",
        //        "event": "-",
        //        "active": false,
        //        "role": "Организатор",
        //        "status": "Отправлено приглашение 25.07.2016 18:43",
        //        "statusclass": "text-primary",
        //        "id": "4"
        //    },
        //    {
        //        "fname": "Григори",
        //        "sname": "Хаус",
        //        "email": "grag@housemd.com",
        //        "phone": "+7 (495) 6968899",
        //        "company": "ИП Викодиныч",
        //        "event": "8 А.Кролл, Л.Ролл, М. Волл День джаза в Доме музыки. \"Все цвета московского джаза\"",
        //        "active": false,
        //        "role": "Старший оператор",
        //        "status": "Назначен на вход, Вход 17",
        //        "statusclass": "",
        //        "id": "5"
        //    },
        //    {
        //        "fname": "Надежда",
        //        "sname": "Новая",
        //        "email": "newhope@voinazvezda.ru",
        //        "phone": "+7 (495) 6968899",
        //        "company": "ООО Шум о Звездах",
        //        "event": "-",
        //        "active": false,
        //        "role": "Старший оператор",
        //        "status": "",
        //        "statusclass": "",
        //        "button": "Акцепт регистрации",
        //        "id": "6"
        //    },
        //]

        if (!$rootScope.userlist) $scope.Promise = userService.getListUsers();

        $rootScope.createUser = function create_user() {
            console.log('create user');
            app.closeSecond();
            app.loadContentView('/main/user/user.create.html', 1800);
        }

        $rootScope.showUser = function edit_user() {
            console.log('create user');
            app.closeSecond();
            app.loadContentView('/main/user/user.viewone.html', 1800);
        }

        $rootScope.inviteUser= function invite_user() {
            console.log('create user');
            app.closeSecond();
            app.loadContentView('/main/user/user.invite.html', 1800);
        }
    }
})();