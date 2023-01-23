﻿// <copyright file="SettingsData.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>
// <auto-generated />

namespace PublicDomain
{
    // Directives
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Urlister settings.
    /// </summary>
    public class SettingsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PublicDomain.SettingsData"/> class.
        /// </summary>
        public SettingsData()
        {
            // Parameterless constructor
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> always on top.
        /// </summary>
        /// <value><c>true</c> if always on top; otherwise, <c>false</c>.</value>
        public bool AlwaysOnTop { get; set; } = false;

        /// <summary>
        /// Gets or sets the last.
        /// </summary>
        /// <value>The last.</value>
        public string last { get; set; } = "Min. length";

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> apply last on open.
        /// </summary>
        /// <value><c>true</c> if apply last on open; otherwise, <c>false</c>.</value>
        public bool ApplyLastOnOpen { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> remove blank lines.
        /// </summary>
        /// <value><c>true</c> if remove blank lines; otherwise, <c>false</c>.</value>
        public bool RemoveBlankLines { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> trim lines.
        /// </summary>
        /// <value><c>true</c> if trim lines; otherwise, <c>false</c>.</value>
        public bool TrimLines { get; set; } = false;
    }
}