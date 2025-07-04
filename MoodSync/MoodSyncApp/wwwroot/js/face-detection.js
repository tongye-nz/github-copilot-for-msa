// Face Detection JavaScript Functions
window.initializeFaceDetection = () => {
    console.log('Face Detection initialized');
};

window.startCamera = async (videoElement) => {
    try {
        const stream = await navigator.mediaDevices.getUserMedia({ 
            video: { 
                width: 320, 
                height: 240,
                facingMode: 'user' // Front camera
            } 
        });
        videoElement.srcObject = stream;
        videoElement.play();
        console.log('Camera started successfully');
    } catch (error) {
        console.error('Error accessing camera:', error);
        throw error;
    }
};

window.stopCamera = () => {
    const video = document.getElementById('cameraVideo');
    if (video && video.srcObject) {
        const stream = video.srcObject;
        const tracks = stream.getTracks();
        tracks.forEach(track => track.stop());
        video.srcObject = null;
        console.log('Camera stopped');
    }
};

window.captureFrame = (videoElement, canvasElement) => {
    try {
        const canvas = canvasElement;
        const video = videoElement;
        
        // Set canvas dimensions to match video
        canvas.width = video.videoWidth || 320;
        canvas.height = video.videoHeight || 240;
        
        // Draw current video frame to canvas
        const ctx = canvas.getContext('2d');
        ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
        
        // Convert canvas to base64 data URL
        const imageData = canvas.toDataURL('image/jpeg', 0.8);
        console.log('Frame captured successfully');
        return imageData;
    } catch (error) {
        console.error('Error capturing frame:', error);
        return null;
    }
};

// Mock face detection (in real implementation, this would use a proper AI service)
window.mockFaceDetection = (imageData) => {
    // Simulate processing delay
    return new Promise((resolve) => {
        setTimeout(() => {
            const emotions = ['happy', 'sad', 'angry', 'surprised', 'neutral', 'tired'];
            const randomEmotion = emotions[Math.floor(Math.random() * emotions.length)];
            const confidence = 0.7 + (Math.random() * 0.3);
            
            resolve({
                faceDetected: Math.random() > 0.1, // 90% success rate
                emotion: randomEmotion,
                confidence: confidence
            });
        }, 1000);
    });
};

// Add visual feedback for face detection
window.addFaceDetectionOverlay = (videoElement) => {
    const overlay = document.createElement('div');
    overlay.style.position = 'absolute';
    overlay.style.top = '0';
    overlay.style.left = '0';
    overlay.style.width = '100%';
    overlay.style.height = '100%';
    overlay.style.border = '2px solid #00ff00';
    overlay.style.borderRadius = '10px';
    overlay.style.pointerEvents = 'none';
    overlay.style.animation = 'pulse 1s infinite';
    
    videoElement.parentElement.appendChild(overlay);
    
    setTimeout(() => {
        overlay.remove();
    }, 2000);
};

// Helper function to check if camera is available
window.checkCameraAvailability = async () => {
    try {
        const devices = await navigator.mediaDevices.enumerateDevices();
        const videoDevices = devices.filter(device => device.kind === 'videoinput');
        return videoDevices.length > 0;
    } catch (error) {
        console.error('Error checking camera availability:', error);
        return false;
    }
};
