export async function uploadVideo(selectedFile: File) {
    if (selectedFile) {
        const formData = new FormData();
        formData.append("video", selectedFile);

        try {
            const response = await fetch("http://localhost:5299/api/videos", {
                method: "POST",
                body: formData,
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