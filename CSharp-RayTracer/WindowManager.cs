using SDL2;
using System;

namespace CSharp_RayTracer
{
    public class WindowManager
    {
        private IntPtr window;
        private IntPtr renderer;
        public WindowManager(int _width,int _height, string _windowName)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("Unable to initialize SDL. Error: {0}", SDL.SDL_GetError());
            }
            else
            {
                window = SDL.SDL_CreateWindow(_windowName,
                    SDL.SDL_WINDOWPOS_CENTERED,
                    SDL.SDL_WINDOWPOS_CENTERED,
                    _width,
                    _height,
                    SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
                );
                if (window == IntPtr.Zero)
                {
                    Console.WriteLine("Unable to create a window. SDL. Error: {0}", SDL.SDL_GetError());  
                }
                renderer = SDL.SDL_CreateRenderer(window,-1,SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            }
        }
        public void DestroyWindow(){
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }

        public bool EventLoop(){
            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        return true;
                }
            }
            return false;
        }

        public void Render(Colour[,] arr){
            SDL.SDL_SetRenderDrawColor(renderer,0,0,0,0);
            SDL.SDL_RenderClear(renderer);
            for(int x = 0; x < 500; x++){
                for(int y = 0; y < 500; y++){
                    SDL.SDL_SetRenderDrawColor(renderer, Convert.ToByte(arr[x,y].r), Convert.ToByte(arr[x,y].g), Convert.ToByte(arr[x,y].b), 255);
                    SDL.SDL_RenderDrawPoint(renderer, 499-x, 499-y);
                }
            }
            SDL.SDL_RenderPresent(renderer);
        }
    }
}