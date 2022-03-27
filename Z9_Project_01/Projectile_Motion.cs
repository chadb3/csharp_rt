using System;
using csharp_rt;


namespace Z9_Project_01
{
    class Projectile
    {
        public tuple position, velocity;
        public Projectile(tuple position, tuple velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }
    }

    class Environment
    {
        public tuple gravity, wind;
        public Environment(tuple gravity, tuple wind)
        {
            this.gravity = gravity;
            this.wind = wind;
        }

        public Projectile tick(Projectile proj)
        {
            tuple new_position = proj.position + proj.velocity;
            tuple updated_velocity = proj.velocity + gravity + wind;
            return new Projectile(new_position,updated_velocity);
        }

    }

    class Projectile_Motion
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            canvas c = new canvas(900, 500);
            c.set_file_name("PROJECTILE");
            //Projectile proj = new Projectile(tuple.point(0, 1, 0), tuple.vector(1, 1, 0));
            Environment env = new Environment(tuple.vector(0, -0.1, 0), tuple.vector(-0.01, 0, 0));
            tuple start = tuple.point(0, 1, 0);
            tuple velocity = tuple.vector(1, 1.8, 0).normalize() * 12.25;
            Projectile proj = new Projectile(start, velocity);
            while(proj.position.y>=0)
            {
                Console.Out.WriteLine(proj.position);
                c.write_pixel(proj.position.x, 500-proj.position.y, color.RED());
                proj=env.tick(proj);
            }
            Console.Out.WriteLine(proj.position);
            c.canvas_to_P3_ppm();
            Console.ReadLine();
        }
    }
}
