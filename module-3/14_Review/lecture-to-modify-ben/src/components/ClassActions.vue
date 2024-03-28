<template>
    <div class="actions">
        <button id='btnAddJavaBlueStudents' v-on:click="addJavaBlueStudentsToList">Add the Java Blue students</button>
        <button id='btnAddJavaGrayStudents' v-on:click="addJavaGrayStudentsToList">Add the Java Gray students</button>
        <button id='btnAddJavaGreenStudents' v-on:click="addJavaGreenStudentsToList">Add the Java Green students</button>
        <button id='btnAddClassPet' v-on:click="showClassPet">Reveal the class pet</button>
        &nbsp;&nbsp;
        <button id="addLI">Add someone else</button>
        <br /><br />
        <div id="listAddDiv" class="d-none">
            <input type="text" id="fname" name="fname" />
            <button>Add</button>
        </div>
    </div>
</template>

<script>
export default {
    methods: {
        showClassPet() {
            this.$store.commit('MAKE_PET_VISIBLE');
        },
        addJavaBlueStudentsToList() {
            if (this.$store.state.javaBlueStudentsAdded) {
                alert('The classroom is already full of Java Blue students. Start teaching!');
            }
            else {
                this.$store.state.javaBlueStudents.forEach((student) => {
                    if (!this.$store.state.inRoom.includes(student)) {
                        this.$store.commit('ADD_STUDENT_TO_CLASS', student);
                    }
                });
                this.$store.commit('UPDATE_JAVABLUE_ADDED', true);
            }
        },
        addJavaGrayStudentsToList() {
            if (this.$store.state.javaGrayStudentsAdded) {
                alert('The classroom is already full of Java Gray students. Start teaching!');
            }
            else {
                this.$store.state.javaGrayStudents.forEach((student) => {
                    if (!this.$store.state.inRoom.includes(student)) {
                        this.$store.commit('ADD_STUDENT_TO_CLASS', student);
                    }
                });
                this.$store.commit('UPDATE_JAVAGRAY_ADDED', true);
            }
        },
        addJavaGreenStudentsToList() {
            if (this.$store.state.javaGreenStudentsAdded) {
                alert('The classroom is already full of Java Green students. Start teaching!');
            }
            else {
                this.$store.state.javaGreenStudents.forEach((student) => {
                    if (!this.$store.state.inRoom.includes(student)) {
                        this.$store.commit('ADD_STUDENT_TO_CLASS', student);
                    }
                });
                this.$store.commit('UPDATE_JAVAGREEN_ADDED', true);
            }
        }
    }
}
</script>

<style>
</style>