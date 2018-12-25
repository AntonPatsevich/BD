function upload(file, path, folder_name) {
    var BYTES_PER_CHUNK = 1024 * 1024; // sample chunk sizes.
    //upload content
    var start = 0;
    var end = BYTES_PER_CHUNK;
    var completed = 0;
    var count = SIZE % BYTES_PER_CHUNK == 0 ? SIZE / BYTES_PER_CHUNK : Math.floor(SIZE / BYTES_PER_CHUNK) + 1;
    var countStep = 0;


    for (var I = 0; I < file.length; I++) {
        var blob = file[I];
        var SIZE = blob.size;
        var Ftype = blob.type.split('/')[0];
        while (start < SIZE) {
            var chunk = blob.slice(start, end);
            //
            var formData1 = new FormData();
            formData1.append('FileBytes', chunk);
            formData1.append('ConType', Ftype);
            formData1.append('NameFile', blob.name);
            formData1.append('pos', start);
            formData1.append('folderName', folder_name);
            countStep = countStep + 1;
            var xhr = new XMLHttpRequest();
            //xhr.onload = function () {
            //    completed = completed + 1;
            //    //if (completed === count) {
            //    //    uploadComplete();
            //    //}
            //    //var tt = Math.round(completed / count * 100);
            //    //document.getElementById('porg').style.width = tt.toString() + '%';
            //    //document.getElementById('porg').innerText = tt.toString() + '%';
            //};
            xhr.open("POST", path, true);
            xhr.send(formData1);
            start = end;
            end = start + BYTES_PER_CHUNK;
        }
        start = 0;
        end = BYTES_PER_CHUNK;
    }
    return true;
}