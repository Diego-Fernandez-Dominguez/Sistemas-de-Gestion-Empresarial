export class clsPersona {

    private id: number;
    private nombre: string;
    private apellido: string;
    private fechaNac: Date;
    private imagen: string | null;
    private telefono: string | null;
    private idDepartamento: number | null;

    constructor(id: number, nombre: string, apellido: string, fechaNac: Date, imagen: string, telefono: string, idDepartamento: number
    ) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaNac = fechaNac;
        this.imagen = imagen;
        this.telefono = telefono;
        this.idDepartamento = idDepartamento;
    }

    public get Id(): number {
        return this.id;
    }
    public get Nombre(): string {
        return this.nombre;
    }
    public get Apellido(): string {
        return this.apellido;
    }
    public get FechaNac(): Date {
        return this.fechaNac;
    }
    public get Imagen(): string | null {
        return this.imagen;
    }
    public get Telefono(): string | null {
        return this.telefono;
    }
    public get IdDepartamento(): number | null {
        return this.idDepartamento;
    }

    public setNombre(nombre: string): void {
        this.nombre = nombre;
    }
    public setApellido(apellido: string): void {
        this.apellido = apellido;
    }

    public setImagen(imagen: string | null): void {
        this.imagen = imagen;
    }
    public setTelefono(telefono: string | null): void {
        this.telefono = telefono;
    }
    public setIdDepartamento(idDepart: number | null): void {
        this.idDepartamento = idDepart;
    }
}
