﻿import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';



function startAnimation() {
    const container = document.getElementById("threeContainer");
    const canvas = document.createElement("canvas");
    container.appendChild(canvas);

    const scene = new THREE.Scene();
    const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    
    const renderer = new THREE.WebGLRenderer({antialias: true, canvas});

    //const controls = new OrbitControls(camera, renderer);

    renderer.domElement.style.marginTop = "28px";

    renderer.setSize(window.innerWidth, window.innerHeight);
    renderer.setAnimationLoop(animate);
    container.appendChild(renderer.domElement);

    const controls = new OrbitControls(camera, canvas);
    controls.target.set(0, 0, 0);
    controls.update();

    const color = 0xFFFFFF;
    const intensity = 5;
    const light = new THREE.DirectionalLight(color, intensity);
    light.position.set(-4, 5, 4);
    scene.add(light);

    const geometry = new THREE.BoxGeometry(1, 1, 1);
    const material = new THREE.MeshPhongMaterial({ color: 0x00ff00 });
    const cube = new THREE.Mesh(geometry, material);
    scene.add(cube);

    camera.position.z = 5;

    function animate() {

        cube.rotation.x += 0.01;
        cube.rotation.y += 0.01;

        renderer.render(scene, camera);

    }

    renderer.setAnimationLoop(animate);
}

document.addEventListener("DOMContentLoaded", () => {
    startAnimation();
})


