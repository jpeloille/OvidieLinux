using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ovidie.EntityModel.SqlServer.Entities;

namespace Ovidie.EntityModel.SqlServer.Context;

public partial class OvidieDbContext : DbContext
{
    public OvidieDbContext()
    {
    }

    public OvidieDbContext(DbContextOptions<OvidieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAbonnement> TAbonnements { get; set; }

    public virtual DbSet<TAbonnementRecurence> TAbonnementRecurences { get; set; }

    public virtual DbSet<TBeneficiaire> TBeneficiaires { get; set; }

    public virtual DbSet<TCarte> TCartes { get; set; }

    public virtual DbSet<TCentre> TCentres { get; set; }

    public virtual DbSet<TChequier> TChequiers { get; set; }

    public virtual DbSet<TCompte> TComptes { get; set; }

    public virtual DbSet<TEcriture> TEcritures { get; set; }

    public virtual DbSet<TFoliot> TFoliots { get; set; }

    public virtual DbSet<TModePaiement> TModePaiements { get; set; }

    public virtual DbSet<TModele> TModeles { get; set; }

    public virtual DbSet<TModelsDetail> TModelsDetails { get; set; }

    public virtual DbSet<TNature> TNatures { get; set; }

    public virtual DbSet<TNatureCompte> TNatureComptes { get; set; }

    public virtual DbSet<TTier> TTiers { get; set; }

    public virtual DbSet<TTiersAdress> TTiersAdresses { get; set; }

    public virtual DbSet<TTiersFacturette> TTiersFacturettes { get; set; }

    public virtual DbSet<TVentilation> TVentilations { get; set; }

    public virtual DbSet<VAbonnement> VAbonnements { get; set; }

    public virtual DbSet<VVentilation> VVentilations { get; set; }

    public virtual DbSet<ViewEcriture> ViewEcritures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.0.128,1433;Initial Catalog=BD_OVIDIE;Integrated Security=False;User ID=sa;Password=1Modelisation;Trust Server Certificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("French_CI_AS");

        modelBuilder.Entity<TAbonnement>(entity =>
        {
            entity.HasKey(e => e.AboPkUniqueIdentifier);

            entity.ToTable("T_ABONNEMENT");

            entity.Property(e => e.AboPkUniqueIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("ABO_PK_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboActif).HasColumnName("ABO_ACTIF");
            entity.Property(e => e.AboDebutPeriode).HasColumnName("ABO_DEBUT_PERIODE");
            entity.Property(e => e.AboFinPeriode).HasColumnName("ABO_FIN_PERIODE");
            entity.Property(e => e.AboFkCpeUniqueIdentifier).HasColumnName("ABO_FK_CPE_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFkMptUniqueIdentifier).HasColumnName("ABO_FK_MPT_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFkTerUniqueIdentifier).HasColumnName("ABO_FK_TER_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFrequenceDecaissement)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("ABO_FREQUENCE_DECAISSEMENT");
            entity.Property(e => e.AboImpactTauxEndettement).HasColumnName("ABO_IMPACT_TAUX_ENDETTEMENT");
            entity.Property(e => e.AboMontant)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("ABO_MONTANT");
            entity.Property(e => e.AboRemarques)
                .HasColumnType("text")
                .HasColumnName("ABO_REMARQUES");
            entity.Property(e => e.AboTaciteReconduction).HasColumnName("ABO_TACITE_RECONDUCTION");
        });

        modelBuilder.Entity<TAbonnementRecurence>(entity =>
        {
            entity.HasKey(e => e.AboRecPkIdentifier);

            entity.ToTable("T_ABONNEMENT_RECURENCE");

            entity.Property(e => e.AboRecPkIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("ABO_REC_PK_IDENTIFIER");
            entity.Property(e => e.AboRecLabel)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ABO_REC_LABEL");
        });

        modelBuilder.Entity<TBeneficiaire>(entity =>
        {
            entity.HasKey(e => e.BenPkLabel);

            entity.ToTable("T_BENEFICIAIRE");

            entity.Property(e => e.BenPkLabel)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("BEN_PK_LABEL");
        });

        modelBuilder.Entity<TCarte>(entity =>
        {
            entity.HasKey(e => e.CrtPkId);

            entity.ToTable("T_CARTE");

            entity.Property(e => e.CrtPkId)
                .ValueGeneratedNever()
                .HasColumnName("CRT_PK_ID");
            entity.Property(e => e.CrtDevise)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("CRT_DEVISE");
            entity.Property(e => e.CrtEmetteur)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("CRT_EMETTEUR");
            entity.Property(e => e.CrtExpire)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CRT_EXPIRE");
            entity.Property(e => e.CrtFkCpePk).HasColumnName("CRT_FK_CPE_PK");
            entity.Property(e => e.CrtLibelle)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CRT_LIBELLE");
            entity.Property(e => e.CrtNature)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CRT_NATURE");
            entity.Property(e => e.CrtNumero)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CRT_NUMERO");
            entity.Property(e => e.CrtScinder).HasColumnName("CRT_SCINDER");
            entity.Property(e => e.CrtType)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CRT_TYPE");
        });

        modelBuilder.Entity<TCentre>(entity =>
        {
            entity.HasKey(e => e.CtrIdentifier);

            entity.ToTable("T_CENTRES");

            entity.Property(e => e.CtrIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("CTR_IDENTIFIER");
            entity.Property(e => e.CtrCode)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CTR_CODE");
            entity.Property(e => e.CtrLabel)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("CTR_LABEL");
        });

        modelBuilder.Entity<TChequier>(entity =>
        {
            entity.HasKey(e => e.ChqPkId);

            entity.ToTable("T_CHEQUIER");

            entity.Property(e => e.ChqPkId)
                .ValueGeneratedNever()
                .HasColumnName("CHQ_PK_ID");
            entity.Property(e => e.ChkFkCpePkCompteId).HasColumnName("CHK_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.ChqDateReception).HasColumnName("CHQ_DATE_RECEPTION");
            entity.Property(e => e.ChqNumeroDernier)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CHQ_NUMERO_DERNIER");
            entity.Property(e => e.ChqNumeroPremier)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CHQ_NUMERO_PREMIER");
        });

        modelBuilder.Entity<TCompte>(entity =>
        {
            entity.HasKey(e => e.CpePkCompteId);

            entity.ToTable("T_COMPTE");

            entity.Property(e => e.CpePkCompteId)
                .ValueGeneratedNever()
                .HasColumnName("CPE_PK_COMPTE_ID");
            entity.Property(e => e.CpeAVentiler).HasColumnName("CPE_A_VENTILER");
            entity.Property(e => e.CpeBic)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("CPE_BIC");
            entity.Property(e => e.CpeCarteDateprelev).HasColumnName("CPE_CARTE_DATEPRELEV");
            entity.Property(e => e.CpeCarteNumero)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CPE_CARTE_NUMERO");
            entity.Property(e => e.CpeCle)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CPE_CLE");
            entity.Property(e => e.CpeCodeBanque)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CPE_CODE_BANQUE");
            entity.Property(e => e.CpeCodeGuichet)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CPE_CODE_GUICHET");
            entity.Property(e => e.CpeDebitAlerte)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("CPE_DEBIT_ALERTE");
            entity.Property(e => e.CpeDevise)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("CPE_DEVISE");
            entity.Property(e => e.CpeEstFavori).HasColumnName("CPE_EST_FAVORI");
            entity.Property(e => e.CpeEstUtilisable).HasColumnName("CPE_EST_UTILISABLE");
            entity.Property(e => e.CpeIban)
                .HasMaxLength(28)
                .IsFixedLength()
                .HasColumnName("CPE_IBAN");
            entity.Property(e => e.CpeLibelle)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("CPE_LIBELLE");
            entity.Property(e => e.CpeMntDecouvertAutorise)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("CPE_MNT_DECOUVERT_AUTORISE");
            entity.Property(e => e.CpeNumeroCompte)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("CPE_NUMERO_COMPTE");
            entity.Property(e => e.CpeSoldeOuverture)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("CPE_SOLDE_OUVERTURE");
            entity.Property(e => e.CpeType)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CPE_TYPE");
        });

        modelBuilder.Entity<TEcriture>(entity =>
        {
            entity.HasKey(e => e.EcrPkId);

            entity.ToTable("T_ECRITURE");

            entity.Property(e => e.EcrPkId)
                .ValueGeneratedNever()
                .HasColumnName("ECR_PK_ID");
            entity.Property(e => e.EcrBalance)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("ECR_BALANCE");
            entity.Property(e => e.EcrCredit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ECR_CREDIT");
            entity.Property(e => e.EcrDate)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE");
            entity.Property(e => e.EcrDatePointee)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE_POINTEE");
            entity.Property(e => e.EcrDateValeur)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE_VALEUR");
            entity.Property(e => e.EcrDebit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ECR_DEBIT");
            entity.Property(e => e.EcrDevise)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("ECR_DEVISE");
            entity.Property(e => e.EcrFkCpePkCompteId).HasColumnName("ECR_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.EcrFkCrtPk).HasColumnName("ECR_FK_CRT_PK");
            entity.Property(e => e.EcrFkCtrCode)
                .HasMaxLength(10)
                .HasColumnName("ECR_FK_CTR_CODE");
            entity.Property(e => e.EcrFkMptPkModePaiementId).HasColumnName("ECR_FK_MPT_PK_MODE_PAIEMENT_ID");
            entity.Property(e => e.EcrFkTerLabel)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("ECR_FK_TER_LABEL");
            entity.Property(e => e.EcrFlPkTiersId).HasColumnName("ECR_FL_PK_TIERS_ID");
            entity.Property(e => e.EcrIsdebit).HasColumnName("ECR_ISDEBIT");
            entity.Property(e => e.EcrIsdebtratio).HasColumnName("ECR_ISDEBTRATIO");
            entity.Property(e => e.EcrIsrecurrent).HasColumnName("ECR_ISRECURRENT");
            entity.Property(e => e.EcrLabel)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("ECR_LABEL");
            entity.Property(e => e.EcrLettrage)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ECR_LETTRAGE");
            entity.Property(e => e.EcrMontant)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("ECR_MONTANT");
            entity.Property(e => e.EcrMontantDevise)
                .HasColumnType("decimal(16, 2)")
                .HasColumnName("ECR_MONTANT_DEVISE");
            entity.Property(e => e.EcrNumReleve)
                .HasColumnType("numeric(7, 0)")
                .HasColumnName("ECR_NUM_RELEVE");
            entity.Property(e => e.EcrNumero)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ECR_NUMERO");
            entity.Property(e => e.EcrPointageMethode).HasColumnName("ECR_POINTAGE_METHODE");
            entity.Property(e => e.EcrPointee).HasColumnName("ECR_POINTEE");
            entity.Property(e => e.EcrRemarque)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ECR_REMARQUE");
            entity.Property(e => e.EcrTauxChange)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("ECR_TAUX_CHANGE");
        });

        modelBuilder.Entity<TFoliot>(entity =>
        {
            entity.HasKey(e => e.FltPkId);

            entity.ToTable("T_FOLIOT");

            entity.Property(e => e.FltPkId)
                .ValueGeneratedNever()
                .HasColumnName("FLT_PK_ID");
            entity.Property(e => e.FltFkCpePkCompteId).HasColumnName("FLT_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.FltPeriodEnd).HasColumnName("FLT_PERIOD_END");
            entity.Property(e => e.FltPeriodStart).HasColumnName("FLT_PERIOD_START");
            entity.Property(e => e.FltPiece)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FLT_PIECE");
            entity.Property(e => e.FltReconciliationDate).HasColumnName("FLT_RECONCILIATION_DATE");
        });

        modelBuilder.Entity<TModePaiement>(entity =>
        {
            entity.HasKey(e => e.MptPkModePaimentId);

            entity.ToTable("T_MODE_PAIEMENT");

            entity.Property(e => e.MptPkModePaimentId)
                .ValueGeneratedNever()
                .HasColumnName("MPT_PK_MODE_PAIMENT_ID");
            entity.Property(e => e.MptCallkey)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("MPT_CALLKEY");
            entity.Property(e => e.MptEstNumerable).HasColumnName("MPT_EST_NUMERABLE");
            entity.Property(e => e.MptFkCpePkCompteId).HasColumnName("MPT_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.MptIsavalaible).HasColumnName("MPT_ISAVALAIBLE");
            entity.Property(e => e.MptIscredit).HasColumnName("MPT_ISCREDIT");
            entity.Property(e => e.MptIsdebit).HasColumnName("MPT_ISDEBIT");
            entity.Property(e => e.MptLibelle)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("MPT_LIBELLE");
            entity.Property(e => e.MptTailleNumerable)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("MPT_TAILLE_NUMERABLE");
            entity.Property(e => e.MptTransactionDay)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("MPT_TRANSACTION_DAY");
            entity.Property(e => e.MptValidityDay).HasColumnName("MPT_VALIDITY_DAY");
            entity.Property(e => e.MptVerifieNumerable).HasColumnName("MPT_VERIFIE_NUMERABLE");
        });

        modelBuilder.Entity<TModele>(entity =>
        {
            entity.HasKey(e => e.MdlIdentifier);

            entity.ToTable("T_MODELES");

            entity.Property(e => e.MdlIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("MDL_IDENTIFIER");
            entity.Property(e => e.MdlFkCpePkIdentigier).HasColumnName("MDL_FK_CPE_PK_IDENTIGIER");
            entity.Property(e => e.MdlLabel)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("MDL_LABEL");
        });

        modelBuilder.Entity<TModelsDetail>(entity =>
        {
            entity.HasKey(e => e.MdlDetailsIdentifier).HasName("PK_T_MDL_DETAILS");

            entity.ToTable("T_MODELS_DETAILS");

            entity.Property(e => e.MdlDetailsIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("MDL_DETAILS_IDENTIFIER");
            entity.Property(e => e.MdlDetailsBalance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("MDL_DETAILS_BALANCE");
            entity.Property(e => e.MdlDetailsFkCpePkIdentifier).HasColumnName("MDL_DETAILS_FK_CPE_PK_IDENTIFIER");
            entity.Property(e => e.MdlDetailsFkMthPkIdentifier).HasColumnName("MDL_DETAILS_FK_MTH_PK_IDENTIFIER");
            entity.Property(e => e.MdlDetailsFkTerPkIdentifier).HasColumnName("MDL_DETAILS_FK_TER_PK_IDENTIFIER");
            entity.Property(e => e.MdlDetailsOrder).HasColumnName("MDL_DETAILS_ORDER");
        });

        modelBuilder.Entity<TNature>(entity =>
        {
            entity.HasKey(e => e.NatIdentifier).HasName("PK_T_NOMENCLATURE");

            entity.ToTable("T_NATURES");

            entity.Property(e => e.NatIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("NAT_IDENTIFIER");
            entity.Property(e => e.NatClasse)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("NAT_CLASSE");
            entity.Property(e => e.NatLibelle)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("NAT_LIBELLE");
        });

        modelBuilder.Entity<TNatureCompte>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("T_NATURE_COMPTE");

            entity.Property(e => e.NatInformations)
                .HasColumnType("text")
                .HasColumnName("NAT_INFORMATIONS");
            entity.Property(e => e.NatLibelle)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("NAT_LIBELLE");
            entity.Property(e => e.NatPkId).HasColumnName("NAT_PK_ID");
        });

        modelBuilder.Entity<TTier>(entity =>
        {
            entity.HasKey(e => e.TerPkId);

            entity.ToTable("T_TIERS");

            entity.Property(e => e.TerPkId)
                .ValueGeneratedNever()
                .HasColumnName("TER_PK_ID");
            entity.Property(e => e.TerNom)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("TER_NOM");
        });

        modelBuilder.Entity<TTiersAdress>(entity =>
        {
            entity.HasKey(e => e.TadPkId);

            entity.ToTable("T_TIERS_ADRESSES");

            entity.Property(e => e.TadPkId)
                .ValueGeneratedNever()
                .HasColumnName("TAD_PK_ID");
            entity.Property(e => e.TadAdress)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("TAD_ADRESS");
            entity.Property(e => e.TadDistrict)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("TAD_DISTRICT");
            entity.Property(e => e.TadEmail)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("TAD_EMAIL");
            entity.Property(e => e.TadFkTerPkId).HasColumnName("TAD_FK_TER_PK_ID");
            entity.Property(e => e.TadPhone)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TAD_PHONE");
        });

        modelBuilder.Entity<TTiersFacturette>(entity =>
        {
            entity.HasKey(e => e.TftPkUniqueIdentifier);

            entity.ToTable("T_TIERS_FACTURETTES");

            entity.Property(e => e.TftPkUniqueIdentifier)
                .ValueGeneratedNever()
                .HasColumnName("TFT_PK_UNIQUE_IDENTIFIER");
            entity.Property(e => e.TftFpkTerPkId).HasColumnName("TFT_FPK_TER_PK_ID");
            entity.Property(e => e.TftLabel)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("TFT_LABEL");
        });

        modelBuilder.Entity<TVentilation>(entity =>
        {
            entity.HasKey(e => e.VtlPkId);

            entity.ToTable("T_VENTILATION");

            entity.Property(e => e.VtlPkId)
                .ValueGeneratedNever()
                .HasColumnName("VTL_PK_ID");
            entity.Property(e => e.VtlCredit)
                .HasColumnType("money")
                .HasColumnName("VTL_CREDIT");
            entity.Property(e => e.VtlDebit)
                .HasColumnType("money")
                .HasColumnName("VTL_DEBIT");
            entity.Property(e => e.VtlFkCtrPkIdentifier).HasColumnName("VTL_FK_CTR_PK_IDENTIFIER");
            entity.Property(e => e.VtlFkEcrPkId).HasColumnName("VTL_FK_ECR_PK_ID");
            entity.Property(e => e.VtlFkEcrPkIdentifier).HasColumnName("VTL_FK_ECR_PK_IDENTIFIER");
            entity.Property(e => e.VtlFkNmcPkId).HasColumnName("VTL_FK_NMC_PK_ID");
            entity.Property(e => e.VtlIsdebit).HasColumnName("VTL_ISDEBIT");
            entity.Property(e => e.VtlMontant)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("VTL_MONTANT");
        });

        modelBuilder.Entity<VAbonnement>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_ABONNEMENT");

            entity.Property(e => e.AboDebutPeriode).HasColumnName("ABO_DEBUT_PERIODE");
            entity.Property(e => e.AboFinPeriode).HasColumnName("ABO_FIN_PERIODE");
            entity.Property(e => e.AboFkCpeUniqueIdentifier).HasColumnName("ABO_FK_CPE_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFkMptUniqueIdentifier).HasColumnName("ABO_FK_MPT_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFkTerUniqueIdentifier).HasColumnName("ABO_FK_TER_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboFrequenceDecaissement)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ABO_FREQUENCE_DECAISSEMENT");
            entity.Property(e => e.AboImpactTauxEndettement).HasColumnName("ABO_IMPACT_TAUX_ENDETTEMENT");
            entity.Property(e => e.AboMontant)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("ABO_MONTANT");
            entity.Property(e => e.AboPkUniqueIdentifier).HasColumnName("ABO_PK_UNIQUE_IDENTIFIER");
            entity.Property(e => e.AboRemarques)
                .HasColumnType("text")
                .HasColumnName("ABO_REMARQUES");
            entity.Property(e => e.AboTaciteReconduction).HasColumnName("ABO_TACITE_RECONDUCTION");
            entity.Property(e => e.CpeLibelle)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("CPE_LIBELLE");
            entity.Property(e => e.MptLibelle)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("MPT_LIBELLE");
            entity.Property(e => e.TerNom)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("TER_NOM");
        });

        modelBuilder.Entity<VVentilation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_VENTILATIONS");

            entity.Property(e => e.CtrCode)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CTR_CODE");
            entity.Property(e => e.CtrIdentifier).HasColumnName("CTR_IDENTIFIER");
            entity.Property(e => e.CtrLabel)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("CTR_LABEL");
            entity.Property(e => e.VtlCredit)
                .HasColumnType("money")
                .HasColumnName("VTL_CREDIT");
            entity.Property(e => e.VtlDebit)
                .HasColumnType("money")
                .HasColumnName("VTL_DEBIT");
            entity.Property(e => e.VtlFkCtrPkIdentifier).HasColumnName("VTL_FK_CTR_PK_IDENTIFIER");
            entity.Property(e => e.VtlFkEcrPkId).HasColumnName("VTL_FK_ECR_PK_ID");
            entity.Property(e => e.VtlFkEcrPkIdentifier).HasColumnName("VTL_FK_ECR_PK_IDENTIFIER");
            entity.Property(e => e.VtlFkNmcPkId).HasColumnName("VTL_FK_NMC_PK_ID");
            entity.Property(e => e.VtlIsdebit).HasColumnName("VTL_ISDEBIT");
            entity.Property(e => e.VtlMontant)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("VTL_MONTANT");
            entity.Property(e => e.VtlPkId).HasColumnName("VTL_PK_ID");
        });

        modelBuilder.Entity<ViewEcriture>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewECRITURES");

            entity.Property(e => e.EcrDate)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE");
            entity.Property(e => e.EcrDatePointee)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE_POINTEE");
            entity.Property(e => e.EcrDateValeur)
                .HasColumnType("datetime")
                .HasColumnName("ECR_DATE_VALEUR");
            entity.Property(e => e.EcrFkCpePkCompteId).HasColumnName("ECR_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.EcrFkMptPkModePaiementId).HasColumnName("ECR_FK_MPT_PK_MODE_PAIEMENT_ID");
            entity.Property(e => e.EcrFlPkTiersId).HasColumnName("ECR_FL_PK_TIERS_ID");
            entity.Property(e => e.EcrLabel)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("ECR_LABEL");
            entity.Property(e => e.EcrMontant)
                .HasColumnType("numeric(16, 2)")
                .HasColumnName("ECR_MONTANT");
            entity.Property(e => e.EcrNumero)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ECR_NUMERO");
            entity.Property(e => e.EcrPkId).HasColumnName("ECR_PK_ID");
            entity.Property(e => e.EcrPointee).HasColumnName("ECR_POINTEE");
            entity.Property(e => e.EcrRemarque)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ECR_REMARQUE");
            entity.Property(e => e.MptEstNumerable).HasColumnName("MPT_EST_NUMERABLE");
            entity.Property(e => e.MptFkCpePkCompteId).HasColumnName("MPT_FK_CPE_PK_COMPTE_ID");
            entity.Property(e => e.MptIsdebit).HasColumnName("MPT_ISDEBIT");
            entity.Property(e => e.MptLibelle)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("MPT_LIBELLE");
            entity.Property(e => e.MptPkModePaimentId).HasColumnName("MPT_PK_MODE_PAIMENT_ID");
            entity.Property(e => e.MptTailleNumerable)
                .HasColumnType("numeric(2, 0)")
                .HasColumnName("MPT_TAILLE_NUMERABLE");
            entity.Property(e => e.MptVerifieNumerable).HasColumnName("MPT_VERIFIE_NUMERABLE");
            entity.Property(e => e.TerNom)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("TER_NOM");
            entity.Property(e => e.TerPkId).HasColumnName("TER_PK_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
