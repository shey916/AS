using Microsoft.Win32;

namespace AS
{
    public partial class Form1 : Form
    {
        private string rutaArchivoActual = string.Empty;
        private List<Registro> registros = new List<Registro>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvRegistros.Columns.Clear();
            dgvRegistros.Columns.Add("Nombre", "Nombre");
            dgvRegistros.Columns.Add("Carrera", "Carrera");
        }

        private void ActualizarDataGridView()
        {
            dgvRegistros.Rows.Clear();
            foreach (var registro in registros)
            {
                dgvRegistros.Rows.Add(registro.Nombre, registro.Carrera);
            }
        }

        private void btnCrearArchivo_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de datos (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Crear Nuevo Archivo Secuencial";
            saveFileDialog.FileName = "datos.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rutaArchivoActual = saveFileDialog.FileName;

                    File.WriteAllText(rutaArchivoActual, string.Empty);

                    registros.Clear();
                    ActualizarDataGridView();

                    lblArchivoActual.Text = $"Archivo: {Path.GetFileName(rutaArchivoActual)}";
                    MessageBox.Show("Archivo secuencial creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de datos (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Abrir Archivo Secuencial";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rutaArchivoActual = openFileDialog.FileName;

                    CargarArchivo();
                    ActualizarDataGridView();

                    lblArchivoActual.Text = $"Archivo: {Path.GetFileName(rutaArchivoActual)}";
                    MessageBox.Show($"Archivo secuencial cargado: {registros.Count} registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarArchivo()
        {
            registros.Clear();

            if (!File.Exists(rutaArchivoActual))
                return;

            using (StreamReader sr = new StreamReader(rutaArchivoActual))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        Registro registro = Registro.FromFileString(linea);
                        if (registro != null)
                        {
                            registros.Add(registro);
                        }
                    }
                }
            }
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivoActual))
            {
                MessageBox.Show("Primero crea o abre un archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Por favor completa todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Registro nuevoRegistro = new Registro(txtNombre.Text.Trim(), txtCarrera.Text.Trim());

                registros.Add(nuevoRegistro);
                ActualizarDataGridView();

                LimpiarCampos();
                MessageBox.Show("Registro agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Por favor completa todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int indiceSeleccionado = dgvRegistros.SelectedRows[0].Index;
                
                if (indiceSeleccionado >= 0 && indiceSeleccionado < registros.Count)
                {
                    registros[indiceSeleccionado].Nombre = txtNombre.Text.Trim();
                    registros[indiceSeleccionado].Carrera = txtCarrera.Text.Trim();

                    ActualizarDataGridView();
                    LimpiarCampos();
                    MessageBox.Show("Registro modificado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int indiceSeleccionado = dgvRegistros.SelectedRows[0].Index;

                    if (indiceSeleccionado >= 0 && indiceSeleccionado < registros.Count)
                    {
                        registros.RemoveAt(indiceSeleccionado);

                        ActualizarDataGridView();
                        LimpiarCampos();
                        MessageBox.Show("Registro eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivoActual))
            {
                MessageBox.Show("Primero crea o abre un archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingresa un nombre o carrera para buscar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string textoBuscar = txtBuscar.Text.Trim().ToLower();

                // Búsqueda secuencial por nombre o carrera
                var resultados = registros
                    .Select((registro, index) => new { Registro = registro, Index = index })
                    .Where(x => x.Registro.Nombre.ToLower().Contains(textoBuscar) || 
                               x.Registro.Carrera.ToLower().Contains(textoBuscar))
                    .ToList();

                if (resultados.Any())
                {
                    // Si hay múltiples resultados, mostrar el primero
                    var primerResultado = resultados.First();
                    
                    txtNombre.Text = primerResultado.Registro.Nombre;
                    txtCarrera.Text = primerResultado.Registro.Carrera;

                    // Seleccionar en el DataGridView
                    dgvRegistros.ClearSelection();
                    dgvRegistros.Rows[primerResultado.Index].Selected = true;
                    dgvRegistros.FirstDisplayedScrollingRowIndex = primerResultado.Index;

                    string mensaje = $"Se encontraron {resultados.Count} resultado(s):\n\n";
                    mensaje += $"Mostrando primer resultado:\n";
                    mensaje += $"Nombre: {primerResultado.Registro.Nombre}\n";
                    mensaje += $"Carrera: {primerResultado.Registro.Carrera}\n\n";
                    mensaje += $"Posición en archivo (secuencial): {primerResultado.Index}";

                    if (resultados.Count > 1)
                    {
                        mensaje += $"\n\nSe encontraron {resultados.Count - 1} resultado(s) adicional(es).";
                    }

                    MessageBox.Show(mensaje, "Registro(s) Encontrado(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No se encontró ningún registro que contenga: '{txtBuscar.Text}'", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivoActual) || !File.Exists(rutaArchivoActual))
            {
                MessageBox.Show("No hay ningún archivo abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FileInfo archivoDatos = new FileInfo(rutaArchivoActual);

                string propiedades = "=== PROPIEDADES DEL ARCHIVO SECUENCIAL ===\n\n";
                propiedades += $"Nombre: {archivoDatos.Name}\n";
                propiedades += $"Ruta: {archivoDatos.FullName}\n";
                propiedades += $"Tamaño: {archivoDatos.Length} bytes ({(archivoDatos.Length / 1024.0):N2} KB)\n";
                propiedades += $"Fecha Creación: {archivoDatos.CreationTime:dd/MM/yyyy HH:mm:ss}\n";
                propiedades += $"Última Modificación: {archivoDatos.LastWriteTime:dd/MM/yyyy HH:mm:ss}\n";
                propiedades += $"Último Acceso: {archivoDatos.LastAccessTime:dd/MM/yyyy HH:mm:ss}\n";
                propiedades += $"Solo Lectura: {(archivoDatos.IsReadOnly ? "Sí" : "No")}\n";
                propiedades += $"Extensión: {archivoDatos.Extension}\n\n";

                propiedades += "=== ESTADÍSTICAS ===\n\n";
                propiedades += $"Total de registros: {registros.Count}\n";
                propiedades += $"Tamaño promedio por registro: {(registros.Count > 0 ? archivoDatos.Length / registros.Count : 0)} bytes\n";
                propiedades += $"Tipo de archivo: Secuencial\n";

                MessageBox.Show(propiedades, "Propiedades del Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener propiedades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistros.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRegistros.SelectedRows[0];
                txtNombre.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                txtCarrera.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCarrera.Clear();
            txtBuscar.Clear();
        }

        private void btnCrearCarpeta_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Selecciona la ubicación donde crear la carpeta";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string nombreCarpeta = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingresa el nombre de la nueva carpeta:",
                    "Crear Carpeta",
                    "NuevaCarpeta");

                if (!string.IsNullOrWhiteSpace(nombreCarpeta))
                {
                    try
                    {
                        string rutaNuevaCarpeta = Path.Combine(folderBrowserDialog.SelectedPath, nombreCarpeta);

                        if (Directory.Exists(rutaNuevaCarpeta))
                        {
                            MessageBox.Show("La carpeta ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Directory.CreateDirectory(rutaNuevaCarpeta);
                        MessageBox.Show($"Carpeta creada exitosamente:\n{rutaNuevaCarpeta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear carpeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRenombrar_Click(object sender, EventArgs e)
        {
            // Mostrar opciones al usuario
            DialogResult opcion = MessageBox.Show(
                "¿Deseas renombrar un ARCHIVO?\n\nSí = Archivo\nNo = Carpeta",
                "Seleccionar Tipo",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (opcion == DialogResult.Cancel)
                return;

            if (opcion == DialogResult.Yes)
            {
                // Renombrar Archivo
                using OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Selecciona el archivo a renombrar";
                openFileDialog.Filter = "Todos los archivos (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaOriginal = openFileDialog.FileName;
                        string nombreActual = Path.GetFileName(rutaOriginal);
                        string extension = Path.GetExtension(rutaOriginal);
                        string nombreSinExtension = Path.GetFileNameWithoutExtension(rutaOriginal);

                        string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                            $"Ingresa el nuevo nombre (extensión actual: {extension}):",
                            "Renombrar Archivo",
                            nombreSinExtension);

                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            string directorio = Path.GetDirectoryName(rutaOriginal) ?? string.Empty;
                            string nombreCompleto = nuevoNombre.Contains('.') ? nuevoNombre : nuevoNombre + extension;
                            string nuevaRuta = Path.Combine(directorio, nombreCompleto);

                            if (File.Exists(nuevaRuta))
                            {
                                MessageBox.Show("Ya existe un archivo con ese nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            File.Move(rutaOriginal, nuevaRuta);

                            // Actualizar si es el archivo actual
                            if (rutaArchivoActual == rutaOriginal)
                            {
                                rutaArchivoActual = nuevaRuta;
                                lblArchivoActual.Text = $"Archivo: {Path.GetFileName(nuevaRuta)}";
                            }

                            MessageBox.Show($"Archivo renombrado exitosamente a:\n{nombreCompleto}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al renombrar archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Renombrar Carpeta
                using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Selecciona la carpeta a renombrar";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaOriginal = folderBrowserDialog.SelectedPath;
                        string nombreActual = new DirectoryInfo(rutaOriginal).Name;

                        string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                            "Ingresa el nuevo nombre de la carpeta:",
                            "Renombrar Carpeta",
                            nombreActual);

                        if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            string directorioPadre = Directory.GetParent(rutaOriginal)?.FullName ?? string.Empty;
                            string nuevaRuta = Path.Combine(directorioPadre, nuevoNombre);

                            if (Directory.Exists(nuevaRuta))
                            {
                                MessageBox.Show("Ya existe una carpeta con ese nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            Directory.Move(rutaOriginal, nuevaRuta);
                            MessageBox.Show($"Carpeta renombrada exitosamente a:\n{nuevoNombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al renombrar carpeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivoActual))
            {
                MessageBox.Show("Primero crea o abre un archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Escritura secuencial completa del archivo
                using (StreamWriter sw = new StreamWriter(rutaArchivoActual, false))
                {
                    foreach (var registro in registros)
                    {
                        sw.WriteLine(registro.ToFileString());
                    }
                }

                MessageBox.Show($"Cambios guardados exitosamente\n{registros.Count} registros guardados en formato secuencial", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"El archivo está siendo usado por otro proceso.\nCierra cualquier programa que esté usando el archivo e intenta nuevamente.\n\nDetalles: {ioEx.Message}", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarArchivo_Click(object sender, EventArgs e)
        {
            // Seleccionar el archivo a copiar
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecciona el archivo a copiar";
            openFileDialog.Filter = "Todos los archivos (*.*)|*.*|Archivos de datos (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string archivoOrigen = openFileDialog.FileName;
                    string nombreArchivo = Path.GetFileName(archivoOrigen);

                    // Seleccionar la carpeta de destino
                    using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    folderBrowserDialog.Description = "Selecciona la carpeta de destino";

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string carpetaDestino = folderBrowserDialog.SelectedPath;
                        string archivoDestino = Path.Combine(carpetaDestino, nombreArchivo);

                        // Verificar si el archivo ya existe en el destino
                        if (File.Exists(archivoDestino))
                        {
                            DialogResult sobrescribir = MessageBox.Show(
                                $"El archivo '{nombreArchivo}' ya existe en la carpeta de destino.\n\n¿Deseas sobrescribirlo?",
                                "Archivo Existente",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (sobrescribir == DialogResult.No)
                            {
                                // Ofrecer renombrar el archivo
                                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                                    "Ingresa un nuevo nombre para el archivo:",
                                    "Renombrar Archivo",
                                    Path.GetFileNameWithoutExtension(nombreArchivo));

                                if (string.IsNullOrWhiteSpace(nuevoNombre))
                                    return;

                                string extension = Path.GetExtension(nombreArchivo);
                                nombreArchivo = nuevoNombre + extension;
                                archivoDestino = Path.Combine(carpetaDestino, nombreArchivo);
                            }
                        }

                        // Copiar el archivo
                        File.Copy(archivoOrigen, archivoDestino, true);

                        MessageBox.Show(
                            $"Archivo secuencial copiado exitosamente:\n{archivoDestino}",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show(
                        $"Error al copiar el archivo.\nAsegúrate de que el archivo no esté siendo usado por otro proceso.\n\nDetalles: {ioEx.Message}",
                        "Error de E/S",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException authEx)
                {
                    MessageBox.Show(
                        $"No tienes permisos para acceder al archivo o carpeta.\n\nDetalles: {authEx.Message}",
                        "Error de Permisos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error al copiar archivo: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}