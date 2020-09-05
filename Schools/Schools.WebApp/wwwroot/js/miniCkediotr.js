ClassicEditor
    .create(document.querySelector('#Description'), {
        toolbar: {
            items: [
                'heading',
                '|',
                'fontSize',
                'bold',
                'italic',
                '|',
                'bulletedList',
                'numberedList',
                '|',
                'indent',
                'outdent',
                '|',
                'undo',
                'redo',
            ]
        },
        language: 'fa',
        licenseKey: '',
    })
    .then(editor => {
        window.editor = editor;
    });
$(document).ready(function () {
    $(".ck-voice-label").css("display", "none");
});