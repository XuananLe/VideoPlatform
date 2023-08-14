<script lang="ts">
    import { onMount } from "svelte";
    import { goto } from "$app/navigation";

    onMount(() => {
        fetch("http://localhost:5299/api/Home")
        .then((res) => res.json())
        .then((res) => {
            console.log(res['message']);
        })
        .catch((err) => {
            console.log(err);
        });
    });
</script>

