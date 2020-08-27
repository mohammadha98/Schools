ClassicEditor
    .create(document.querySelector('#ticket_text'), {
        ckfinder: {
            uploadUrl: '/Upload/UploadTicketImages'
        },
        toolbar: {
            items: [
                'heading',
                '|',
                'fontSize',
                'bold',
                'italic',
                'link',
                '|',
                'bulletedList',
                'numberedList',
                '|',
                'codeblock',
                'imageUpload',
                'blockQuote',
                'insertTable',
                '|',
                'indent',
                'outdent',
                '|',
                'undo',
                'redo',
            ]
        },
        language: 'fa',
        image: {
            toolbar: [
                'imageTextAlternative',
                'imageStyle:full',
                'imageStyle:side'
            ]
        },
        table: {
            contentToolbar: [
                'tableColumn',
                'tableRow',
                'mergeTableCells'
            ]
        },
        licenseKey: '',

    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(error => {
        console.error('Oops, something gone wrong!');
        console.error('Please, report the following error in the https://github.com/ckeditor/ckeditor5 with the build id and the error stack trace:');
        console.warn('Build id: 1hgh63bxm5nk-t1efehf8ocs2');
        console.error(error);
    });

$(document).ready(function() {
    $(".ck-voice-label").css("display", "none");    
});