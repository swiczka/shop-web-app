import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import { GUI } from 'three/addons/libs/lil-gui.module.min.js';

const cameraOffset = 3.75;


async function startAnimation() {
    const container = document.getElementById("threeContainer");
    const canvas = document.createElement("canvas");
    canvas.style.zIndex = 0; 

    container.appendChild(canvas);

    const scene = new THREE.Scene();
    const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    
    const renderer = new THREE.WebGLRenderer({ antialias: true, canvas });
    renderer.shadowMap.enabled = true;

    //const controls = new OrbitControls(camera, renderer);

    renderer.domElement.style.marginTop = "28px";

    renderer.setSize(window.innerWidth, window.innerHeight);
    renderer.setAnimationLoop(animate);
    container.appendChild(renderer.domElement);

    const controls = new OrbitControls(camera, canvas);
    controls.target.set(0, cameraOffset, 0);
    controls.update();

    {
        const loader = new THREE.TextureLoader();
        const backgroundTexture = loader.load('/resources/images/qwantani_mid_morning_puresky.jpg',
            () => {
                backgroundTexture.mapping = THREE.EquirectangularReflectionMapping;
                backgroundTexture.colorSpace = THREE.SRGBColorSpace;
                scene.background = backgroundTexture;
                scene.environment = backgroundTexture;
            });
        
    }

    {
        const ambient = new THREE.AmbientLight(0xFFFFFF, 0.5);
        scene.add(ambient);
    }

    { 
        const lightSettings = {
            angle: 120
        };
        const color = 0xFFFFFF;
        const intensity = 2;
        const light = new THREE.DirectionalLight(color, intensity);
        light.castShadow = true;
        light.shadow.radius = 4;
        const r = 40;
        light.position.set(r * Math.cos(lightSettings.angle * (Math.PI / 180)), 40, r * Math.sin(lightSettings.angle * (Math.PI / 180)));
        scene.add(light);

        const gui = new GUI();
        gui.add(lightSettings, 'angle', 0, 360, 1).onChange((value) => {
            light.position.set(r * Math.cos(value * (Math.PI / 180)), 40, r * Math.sin(value * (Math.PI / 180)));
        });
    }

    {
        const radius = 5;
        const segments = 48;
        const circleGeometry = new THREE.CircleGeometry(radius, segments);
        const loader = new THREE.TextureLoader();
        const texture = loader.load('/resources/images/laminate_floor_02_diff_2k.jpg',
            () => {
                const circleMaterial = new THREE.MeshPhongMaterial({ map: texture });
                const circle = new THREE.Mesh(circleGeometry, circleMaterial);
                circle.receiveShadow = true;
                circle.rotateX(-90 * (Math.PI / 180));
                scene.add(circle);
            });
    }
    
  
    camera.position.z = 5;
    camera.position.y = cameraOffset;

    const gltfLoader = new GLTFLoader();

    var clock, mixer;
    clock = new THREE.Clock();

    const modelUrl = modelData.modelUrl;
    console.log(modelUrl);
   
    await loadMan();

    async function loadMan() {

        return new Promise((resolve, reject) => {
            gltfLoader.load(modelUrl,
                function (gltf)  {
                    const man = gltf.scene;

                    man.traverse((child) => { //man is a group that needs to be iterated
                        if (child.isMesh) {
                            child.material.roughness = 0.8;
                            child.material.reflectivity = 0.15;
                            child.material.normalScale = new THREE.Vector2(1, 1);
                            child.castShadow = true;
                        }
                    });

                    scene.add(man);

                    if (gltf.animations && gltf.animations.length > 0) {
                        mixer = new THREE.AnimationMixer(man);
                        mixer.timeScale = 3;
                        gltf.animations.forEach((clip) => {
                            const action = mixer.clipAction(clip);
                            action.loop = THREE.LoopRepeat;
                            action.play();
                        });
                    }

                    resolve(man);
                },
                undefined,
                function (error) {
                    console.error('An error occurred while loading the model:', error);
                    reject(error);
                }
            );
        });
    }

    function animate() {

        renderer.render(scene, camera);
        if (mixer) mixer.update(clock.getDelta());
    }

    renderer.setAnimationLoop(animate);
}




document.addEventListener("DOMContentLoaded", async () => {
    await startAnimation();
})


