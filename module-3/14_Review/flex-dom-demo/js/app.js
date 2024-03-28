let cat = null;
let ben = null;
let quiet = true;
let javaGrayStudentsAdded = false;
let javaGreenStudentsAdded = false;
let javaBlueStudentsAdded = false;
let opposite = false;

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
    const theList = document.getElementById('classroom');
    cat = document.getElementById('mover');
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

    document.addEventListener('mousemove', (event) => {
        if (!quiet) {
            cat.style.left = event.pageX+4 + 'px';
            cat.style.top = event.pageY+4 + 'px';
            cat.style.transform = 'rotate('+((event.pageX-event.pageY) % 50)+'deg';
        }
    });
    
    ben.addEventListener('click', (event) => { quiet = !quiet; });
    theList.addEventListener('click', leaveRoom);
});    

function addNameToList() {
    const fname = document.getElementById('fname').value;
    const theList = document.getElementById('classroom');
    if (fname == '') {
        // Do nothing
    }
    else if (fname == 'Tasha') {
        alert('Wonderful! Tasha is always welcome.');
        quiet = false;
        const tasha = document.getElementById('mover');
        tasha.style.visibility = 'visible';
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
        else if (javaBlueStudents.includes(fname)) {
            theOther.setAttribute('class', 'javablue');
        }
        else if (javaGrayStudents.includes(fname)) {
            theOther.setAttribute('class', 'javagray');
        }
        else if (javaGreenStudents.includes(fname)) {
            theOther.setAttribute('class', 'javagreen');
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

function addJavaStudentsToList() {
    if (javaStudentsAdded && csharpStudentsAdded) {
        alert('The classroom is already full of students. Start teaching!');
    }
    else if (javaStudentsAdded) {
        alert('The classroom is already full of Java students. Start teaching!');
    }
    else {
        const theList = document.getElementById('classroom');

        javaStudents.forEach((student) => {
            if (!inRoom.includes(student)) {
                const theOther = document.createElement('li');
                theOther.innerText = student;
                theOther.setAttribute('class', 'java');
                if (opposite) {
                    theList.insertBefore(theOther, theList.firstChild);
                }
                else {
                    theList.appendChild(theOther);
                }
                opposite = !opposite;
                inRoom.push(student);
            }
        });
        javaStudentsAdded = true;
    }
}


function addCSharpStudentsToList() {
    if (javaStudentsAdded && csharpStudentsAdded) {
        alert('The classroom is already full of students. Start teaching!');
    }
    else if (csharpStudentsAdded) {
        alert('The classroom is already full of C# students. Start teaching!');
    }
    else {
        const theList = document.getElementById('classroom');

        csharpStudents.forEach((student) => {
            if (!inRoom.includes(student)) {
                const theOther = document.createElement('li');
                theOther.setAttribute('class', 'dotNet');
                theOther.innerText = student;
                if (opposite) {
                    theList.insertBefore(theOther, theList.firstChild);
                }
                else {
                    theList.appendChild(theOther);
                }
                opposite = !opposite;
                inRoom.push(student);
            }
        });
        csharpStudentsAdded = true;
    }
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
                theOther.setAttribute('class', 'javagray');
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
                theOther.setAttribute('class', 'javagreen');
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
                theOther.setAttribute('class', 'javablue');
                theList.appendChild(theOther);
                inRoom.push(student);
            }
        });
        javaBlueStudentsAdded = true;
    }
}

function leaveRoom(event) {
    if (event.target.nodeName.toLowerCase() === "li" && event.target.innerText) {
        let choice = event.target.innerText;
        if (choice == 'Ben') {
            // Do nothing, as click has other meaning
        } else if (javaGrayStudents.includes(choice)) {
            alert(choice + " can't leave. Class is starting soon.");
        } else if (javaBlueStudents.includes(choice)) {
            inRoom = inRoom.filter((student) => { return student != choice});
            event.currentTarget.removeChild(event.target);
            javaBlueStudentsAdded = false;
        } else if (javaGreenStudents.includes(choice)) {
            inRoom = inRoom.filter((student) => { return student != choice});
            event.currentTarget.removeChild(event.target);
            javaGreenStudentsAdded = false;
        } else {
            inRoom = inRoom.filter((student) => { return student != choice});
            event.currentTarget.removeChild(event.target);
        }
    } 
}

