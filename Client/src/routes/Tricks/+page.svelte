<!-- <script>
	import { uploadVideo } from './uploadVideos';
	let selectedFile = null;
	
</script>

<main>
	<h1>Upload Video</h1>
	<input type="file" bind:files={selectedFile} />
	<button on:click={uploadVideo(selectedFile)}>Upload</button>
</main>

<style>
	main {
		max-width: 600px;
		margin: 0 auto;
		padding: 2rem;
	}
</style> -->
<script>
  let foo = "baz";
  let bar = "qux";
  let result = null;

  async function doPost() {
    const res = await fetch("http://localhost:5299/api/Videos/Upload", {
      method: "POST",
      body: "123",
      headers: {
        "Content-Type": "application/json", // Corrected Content-Type header
      }
    });

    const json = await res.json();
    result = JSON.stringify(json);
  }
</script>

<input bind:value={foo} />
<input bind:value={bar} />
<button type="button" on:click={doPost}> Post it. </button>
<p>Result:</p>
<pre>
{result}
</pre>
