console.log("hello");

//requiring path and fs modules
const testFolder = './ok/';
const fs = require('fs');

fs.readdir(testFolder, (err, files) => {
  files.forEach(file => {
    console.log(file);
    // console.log(file.)
  });

  console.log(files)



});

function walk(currentDirPath, callback) {
    var fs = require('fs'),
        path = require('path');
    fs.readdir(currentDirPath, function (err, files) {
        if (err) {
            throw new Error(err);
        }
        files.forEach(function (name) {
            var filePath = path.join(currentDirPath, name);
            var stat = fs.statSync(filePath);
            if (stat.isFile()) {
                callback(filePath, stat);
            } else if (stat.isDirectory()) {
                walk(filePath, callback);
            }
        });
    });
}

function processFile(inputFile) {
    var fs = require('fs'),
        readline = require('readline'),
        instream = fs.createReadStream(inputFile),
        outstream = new (require('stream'))(),
        rl = readline.createInterface(instream, outstream);
     
    rl.on('line', function (line) {
        console.log(line);
    });
    
    rl.on('close', function (line) {
        console.log(line);
        console.log('done reading file.');
    });
}


let project_name = './Angular-JumpStart/'; 

walk(project_name, function(filePath, stat) {
    // do something with "filePath"...
    console.log(filePath)
    // processFile(filePath)
});

// const fs = require('fs');

// function walk(currentDirPath, callback) {
//     var fs = require('fs'),
//         path = require('path');
//     fs.readdir(currentDirPath, function (err, files) {
//         if (err) {
//             throw new Error(err);
//         }
//         files.forEach(function (name) {
//             var filePath = path.join(currentDirPath, name);
//             var stat = fs.statSync(filePath);
//             if (stat.isFile()) {
//                 callback(filePath, stat);
//             } else if (stat.isDirectory()) {
//                 walk(filePath, callback);
//             }
//         });
//     });
// }

// function getFilesPath(projectPath) {

//     let filePaths = new Array();
//     // console.log()

//     walk('../'+projectPath, function(filePath, stat) {
//         filePaths.push(filePath);
//     });

//     return filePaths;
// }

// // var projectFileReader = require('./src/projectReader')

// let arr = getFilesPath('./Angular-JumpStart/')

// console.log(arr.length)

// console.log('hello')