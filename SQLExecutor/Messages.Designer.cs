﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLExecutor {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SQLExecutor.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Correo Electrónico enviado correctamente.
        /// </summary>
        internal static string EMAIL_SEND_OK {
            get {
                return ResourceManager.GetString("EMAIL_SEND_OK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al abrir la conexion.
        /// </summary>
        internal static string ERROR_OPEN_CONNECTION {
            get {
                return ResourceManager.GetString("ERROR_OPEN_CONNECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error durante la ejecucion del script, revise la lista de errores.
        /// </summary>
        internal static string ERROR_RUN_SCRIPTS {
            get {
                return ResourceManager.GetString("ERROR_RUN_SCRIPTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al guardar la conexion.
        /// </summary>
        internal static string ERROR_SAVE_CONNECTION {
            get {
                return ResourceManager.GetString("ERROR_SAVE_CONNECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al guardar el esquema de remplazos.
        /// </summary>
        internal static string ERROR_SAVE_REPLACEMENT {
            get {
                return ResourceManager.GetString("ERROR_SAVE_REPLACEMENT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Archivo no existe.
        /// </summary>
        internal static string FILE_NOT_FOUND {
            get {
                return ResourceManager.GetString("FILE_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ejecucion Terminada.
        /// </summary>
        internal static string RUN_SCRIPT_FINISH {
            get {
                return ResourceManager.GetString("RUN_SCRIPT_FINISH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Existen errores en el script.
        /// </summary>
        internal static string RUN_SCRIPT_FINISH_WITH_ERRORS {
            get {
                return ResourceManager.GetString("RUN_SCRIPT_FINISH_WITH_ERRORS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe seleccionar un motor de base de datos.
        /// </summary>
        internal static string SELECT_DATABASE_ENGINE {
            get {
                return ResourceManager.GetString("SELECT_DATABASE_ENGINE", resourceCulture);
            }
        }
    }
}
