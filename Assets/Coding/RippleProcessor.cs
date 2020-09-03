using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *    Copyright (c) 2017 Devon O. Wolfgang
 *
 *    Permission is hereby granted, free of charge, to any person obtaining a copy
 *    of this software and associated documentation files (the "Software"), to deal
 *    in the Software without restriction, including without limitation the rights
 *    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *    copies of the Software, and to permit persons to whom the Software is
 *    furnished to do so, subject to the following conditions:
 *
 *    The above copyright notice and this permission notice shall be included in
 *    all copies or substantial portions of the Software.
 *
 *    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *    THE SOFTWARE.
 */

public class RippleProcessor : MonoBehaviour
{
    public Material RippleMaterial; //Public material so we can place the ripple material shader in it.
    public float MaxAmount = 50f; //This flaot can be changed within the inspect of unity, this is how strong the ripple is.
    [Range(0, 1)] //These flaots can be changed between 0 - 1.
    public float Friction = .9f; //This is how long the ripple is, mine is set at 0.9f.
    private float Amount = 0f; //This is the least amount of time the ripple can be.

    void Update()
    {
        this.RippleMaterial.SetFloat("_Amount", this.Amount); //The ripple will last this amount of time and then finishes at this float.
        this.Amount *= this.Friction; //The tipple will be this storng or weak, this intense.
    }

    public void RippleEffect()
    {
        this.Amount = this.MaxAmount; //The ripple amount will last this amount of time.
        Vector3 pos = Input.mousePosition; //Mouse was orginally used to test the ripple efftec to see if it works.
        this.RippleMaterial.SetFloat("_CenterX", pos.x); //This allows the ripple to work on the x.
        this.RippleMaterial.SetFloat("_CenterY", pos.y); //This allows the ripple to work on the y.
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst) //Void for the ripple image.
    {
        Graphics.Blit(src, dst, this.RippleMaterial); //Renders the ripple effect and communicates to the ripple material.
    }
}