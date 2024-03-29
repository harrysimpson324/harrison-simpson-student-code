<template>
    <li v-bind:class="classColor" v-on:click="removeStudent">{{ studentName }}</li>
</template>

<script>
export default {
    props: ['studentName', 'classColor'],
    methods: {
        removeStudent() {
            if (this.studentName == 'Ben') {
            // Do nothing, as click has other meaning
            } else if (this.$store.state.javaGrayStudents.includes(this.studentName)) {
                alert(this.studentName + " can't leave. Class is starting soon.");
            } else if (this.$store.state.javaBlueStudents.includes(this.studentName)) {
                this.$store.commit('REMOVE_STUDENT_FROM_CLASS', this.studentName);
                this.$store.commit('UPDATE_JAVABLUE_ADDED', false);
            } else if (this.$store.state.javaGreenStudents.includes(this.studentName)) {
                this.$store.commit('REMOVE_STUDENT_FROM_CLASS', this.studentName);
                this.$store.commit('UPDATE_JAVAGREEN_ADDED', false);
            } else {
                this.$store.commit('REMOVE_STUDENT_FROM_CLASS', this.studentName);
            }
        
            
        }
    }
}
</script>

<style scoped>
</style>