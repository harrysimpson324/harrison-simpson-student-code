let ben = null;
let javaGrayStudentsAdded = false;
let javaGreenStudentsAdded = false;
let javaBlueStudentsAdded = false;

const javaBlueStudents = ['Aliriza', 'Andre', 'Aurelia', 'Benjamin', 'Cheryl',
'Chilton.', 'George', 'Israel', 'Jake L.', 'Jamie-Lee', 'Jeremy', 'Jonathan',
'Katherine', 'Maggie', 'Melissa', 'Michael C.', 'Michael M.', 'Saraswati'];

const javaGrayStudents = ['Alison', 'Umer', 'Enrique C.', 'Michael R.',
'Joon', 'Revathi', 'Quynh', 'Harry', 'Karrington', 'Davy', 'Devin', 'Dustin', 
'Jake W.', 'Daniel'];

const javaGreenStudents = ['Andrew', 'Andy', 'Dominique', 'Enrique V.', 'Jamesson',
'Jashon', 'Jasmine', 'Joanne', 'Joseph', 'Paige', 'Pleurat', 'Ron',
'Ryan', 'Shelby', 'Sonal', 'Vivek', 'Zachary'];

const students = javaGrayStudents.concat(javaGreenStudents).concat(javaBlueStudents);


let inRoom = ['Ben'];

const instructors = ['Ben', 'Anthony', 'Rich', 'Ellen'];

document.addEventListener('DOMContentLoaded', () => {
    const addAnother = document.getElementById('addLI');
    ben = document.getElementById('headHoncho');
    main = document.querySelector('main');
    inRoom = ['Ben'];
    
    const btnAddJavaGrayStudents = document.getElementById('btnAddJavaGrayStudents');
    btnAddJavaGrayStudents.addEventListener('click', () => {
        addJavaGrayStudentsToList();
    });

    const btnAddJavaGreenStudents = document.getElementById('btnAddJavaGreenStudents');
    btnAddJavaGreenStudents.addEventListener('click', () => {
        addJavaGreenStudentsToList();
    });

    const btnAddJavaBlueStudents = document.getElementById('btnAddJavaBlueStudents');
    btnAddJavaBlueStudents.addEventListener('click', () => {
        addJavaBlueStudentsToList();
    });



    addAnother.addEventListener('click', () => {
        const fname = document.getElementById('fname').value;
        fname.innerText = '';
        const addDiv = document.getElementById('listAddDiv');
        addDiv.classList.remove('d-none');
        const addBtn = addDiv.querySelector('button');
        addBtn.addEventListener('click', addNameToList);
    });

});    

function addNameToList() {
    const fname = document.getElementById('fname').value;
    const theList = document.getElementById('classroom');
    if (fname == '') {
        // Do nothing
    }
    else if (inRoom.includes(fname)) {
        alert(fname+' is already in the classroom. Pay attention!')
    }
    else if (fname == 'Chandra') {
        const theOther = document.createElement('li');
        theOther.setAttribute('class', 'campusDirector');
        theOther.innerHTML = '<center><em>Chandra<br />Lane</em></center>';
        theList.appendChild(theOther);
        inRoom.push(fname);
    }
    else {
        const theOther = document.createElement('li');
        if (instructors.includes(fname)) {
            theOther.setAttribute('class', 'instructor');
        }
        theOther.innerText = fname;
        theList.appendChild(theOther);
        inRoom.push(fname);        
    }
    const addDiv = document.getElementById('listAddDiv');
    addDiv.classList.add('d-none');
    document.getElementById('fname').value = '';
    document.getElementById('fname').innerText = '';
}

function addJavaGrayStudentsToList() {
    if (javaGrayStudentsAdded) {
        alert('The classroom is already full of Java Gray students. Start teaching!');
    }
    else {
        const theList = document.getElementById('classroom');

        javaGrayStudents.sort(() => (Math.random() > .5) ? 1 : -1).forEach((student) => {
            if (!inRoom.includes(student)) {
                const theOther = document.createElement('li');
                theOther.innerText = student;
                theList.appendChild(theOther);
                inRoom.push(student);
            }
        });
        javaGrayStudentsAdded = true;
    }
}

function addJavaGreenStudentsToList() {
    if (javaGreenStudentsAdded) {
        alert('The classroom is already full of Java Green students. Start teaching!');
    }
    else {
        const theList = document.getElementById('classroom');

        javaGreenStudents.sort(() => (Math.random() > .5) ? 1 : -1).forEach((student) => {
            if (!inRoom.includes(student)) {
                const theOther = document.createElement('li');
                theOther.innerText = student;
                theList.appendChild(theOther);
                inRoom.push(student);
            }
        });
        javaGreenStudentsAdded = true;
    }
}

function addJavaBlueStudentsToList() {
    if (javaBlueStudentsAdded) {
        alert('The classroom is already full of Java Blue students. Start teaching!');
    }
    else {
        const theList = document.getElementById('classroom');

        javaBlueStudents.sort(() => (Math.random() > .5) ? 1 : -1).forEach((student) => {
            if (!inRoom.includes(student)) {
                const theOther = document.createElement('li');
                theOther.innerText = student;
                theList.appendChild(theOther);
                inRoom.push(student);
            }
        });
        javaBlueStudentsAdded = true;
    }
}
      