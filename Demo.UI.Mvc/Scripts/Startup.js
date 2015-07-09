function Startup() {
    return {
        iniciar: function () {
            this.configurarCamposBusca();
            this.configurarCamposDate();
        },
        configurarCamposDate: function () {
            $('.datepicker').datepicker();
            $.datepicker.regional['pt-BR'] = {
                closeText: 'Fechar',
                prevText: '&#x3c;Anterior',
                nextText: 'Pr&oacute;ximo&#x3e;',
                currentText: 'Hoje',
                monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho',
                'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
                'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 0,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['pt-BR']);
        },
        configurarCamposBusca: function () {
            $('.campo-busca').change(function () {
                $self = $(this);
                var url = $self.attr('data-url');
                var actionparam = $self.attr('data-param');
                var valor = '&' + actionparam + '=' + encodeURI($self.val());
                $.post(url, valor, function (data) {
                    var campo_alvo = $self.attr('data-campo');
                    if (data) {
                        $('#' + campo_alvo).val(data);
                    } else {
                        $('#' + campo_alvo).val('').focus();
                    }
                });
            });
        }
    };
}