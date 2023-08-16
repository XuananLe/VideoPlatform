export async function uploadVideo(selectedFile: any) {
    console.log("Uploading video...");
    if (true) {
        try {
            let response = await fetch("http://localhost:5299/Upload", {
                method: "POST",
            });

            if (response.ok) {
                console.log("Video uploaded successfully!");
            } else {
                console.error("Error uploading video");
            }
        } catch (error) {
            console.error("Error uploading video:", error);
        }
    }
}