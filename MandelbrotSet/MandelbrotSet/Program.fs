open System
open System.Drawing
open System.Windows.Forms

let mutable size = (double) 1.0
let maxIterations sz = (int) (100.0 / (sqrt sz))

let MapToRange inMin inMax outMin outMax x =
    (x - inMin)
    * (outMax - outMin)
    / (inMax - inMin)
    + outMin

let startx = -((double) 0.73)
let starty = -((double) 0.18)

let rec mandelbrotFunction iterations a b ca cb maxIter =
    if iterations < maxIter
       && a * a + b * b < ((double) 4.0) then
        let asquare = a * a - b * b
        let bsquare = ((double) 2.0) * a * b
        mandelbrotFunction (iterations + 1) (asquare + ca) (bsquare + cb) ca cb maxIter
    else
        iterations

type VisualizeForm() =
    inherit Form()
    override this.OnLoad(e: EventArgs) = this.DoubleBuffered <- true

    override this.OnPaint(e: PaintEventArgs) =
        let g = e.Graphics
        g.Clear(Color.Black)
        let currentMaxIterations = maxIterations size
        for x in 0 .. this.Width do
            for y in 0 .. this.Height do
                let a =
                    startx
                    + MapToRange ((double) 0.0) ((double) this.Width) -size size ((double) x)

                let b =
                    starty
                    + MapToRange ((double) 0.0) ((double) this.Height) -size size ((double) y)

                let iterations =
                    (int)
                        (MapToRange
                            ((double) 0.0)
                             ((double) currentMaxIterations)
                             ((double) 0.0)
                             ((double) 255.0)
                             ((double) (mandelbrotFunction 0 a b a b currentMaxIterations)))

                g.FillRectangle
                    (new SolidBrush(Color.FromArgb
                                        ((iterations * 20) % 255, (iterations * 50) % 255, (iterations * 120) % 255)),
                     x,
                     y,
                     1,
                     1)

let Form =
    new VisualizeForm(MaximizeBox = true, Text = "Mandelbrot Vizualize App", Width = 500, Height = 400)

async {
    while true do
        do! Async.Sleep(1)
        Form.Invalidate()
        size <- (size * 0.9)
}
|> Async.StartImmediate

Application.Run Form


Application.Run Form
