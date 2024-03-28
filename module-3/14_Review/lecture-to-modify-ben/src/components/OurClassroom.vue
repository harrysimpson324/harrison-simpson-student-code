<template>
    <main v-on:mousemove="trackMouse($event)">
        <ul id='classroom'>
            <li id='headHoncho'>Ben</li>
            <class-student v-for="(student, i) in $store.state.inRoom"
                        v-bind:key="i" 
                           v-bind:studentName="student" 
                           v-bind:classColor="calculateClassColor(student)" />
        </ul> 
    </main>
    <class-pet v-show="$store.state.petVisible" />
    <class-actions />
</template>

<script>
import ClassStudent from '../components/ClassStudent.vue'
import ClassActions from '../components/ClassActions.vue'
import ClassPet from '../components/ClassPet.vue'

export default {
    components: {
        ClassStudent,
        ClassActions,
        ClassPet
    },
    methods: {
        calculateClassColor(studentName) {
            if (this.$store.state.javaGrayStudents.includes(studentName)) {
                return 'javagray';
            }
            else if (this.$store.state.javaGreenStudents.includes(studentName)) {
                return 'javagreen';
            }
            else if (this.$store.state.javaBlueStudents.includes(studentName)) {
                return 'javablue';
            }
            else if (this.$store.state.instructors.includes(studentName)) {
                return 'instructor';
            }
            
            return '';
        },
        trackMouse(event) {
            if (!this.$store.state.quiet) {
                let cat = document.getElementById('mover');
                cat.style.left = event.pageX+4 + 'px';
                cat.style.top = event.pageY+4 + 'px';
                cat.style.transform = 'rotate('+((event.pageX-event.pageY) % 50)+'deg';
            }
        }
    }
}
</script>

<style scoped>
main {
    margin: 30px;
}

</style>