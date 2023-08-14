<script>
	import { uploadVideo } from './uploadVideos';
	let selectedFile = null;
</script>

<main>
	<h1>Upload Video</h1>
	<input type="file" accept="video/*" bind:files={selectedFile} />
	<button on:click={uploadVideo}>Upload</button>
</main>

<style>
	main {
		max-width: 600px;
		margin: 0 auto;
		padding: 2rem;
	}
</style>
